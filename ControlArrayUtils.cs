using System;
using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{
    // 
    // ControlArrayUtils.VB - Provide VB6 like support of control arrays
    // 
    // Author -      P Krawec, Inovision Software Solutions, Inc.
    // Date   -      September 1, 2005
    // 
    // This code is free software; you can redistribute it and/or
    // modify it any way you want.
    // This library is distributed in the hope that it will be useful,
    // but without any waranty. 
    // 
    // Any additions or modifications please email to: 
    // kepler77@gmail.com
    // 
    // 
    // How it works:
    // VB.NET does not support control arrays as VB6 did with the index property.
    // There is a way to get around this with minimal coding. 
    // It requires a standard naming convention of the controls.
    // Then the call to one function to search the screen based on that naming 
    // convention to fill an array.
    // 
    // Example:
    // To have a control array of 5 TextBoxes, you would have to name the textboxes 
    // with the following convention:
    // 
    // myTextBox0, myTextBox1, myTextBox2,myTextBox3, myTextBox4
    // 
    // Then in code, you would call: 
    // dim myTextBoxArray as TextBox() = _
    // ControlArrayUtils.getControlArray(FORM, "myTextBox")
    // 
    // The function will then search through all controls directly on the form that 
    // match the name and have an integer value following it.
    // Returning the new control array.
    // 
    // ToDo: 
    // Add exception handling
    // Support recursive searching for controls within other controls.
    // 
    public class ControlArrayUtils
    {

        // Converts same type of controls on a form to a control array by 
        // using the notation ControlName_1, ControlName_2, where the _ 
        // can be replaced by any separator string
        public static Array getControlArray(Form frm, Collection frmControls, string controlName, string separator = "")
        {
            short i;
            int startOfIndex;
            var alist = new ArrayList();
            Type controlType = null;
            string strSuffix;
            short maxIndex = -1; // Default

            // Loop through all controls, looking for controls with the 
            // matching name pattern
            // Find the highest indexed control
            foreach (Control ctl in frmControls)
            {
                startOfIndex = ctl.Name.ToLower().IndexOf(controlName.ToLower() + separator);
                if (startOfIndex == 0)
                {
                    strSuffix = ctl.Name.Substring(controlName.Length);
                    // Check that the suffix is an integer (index of the array)
                    if (IsInteger(strSuffix))
                    {
                        if (Conversions.ToDouble(strSuffix) > maxIndex)
                            maxIndex = Conversions.ToShort(strSuffix); // Find the highest indexed Element
                    }
                }
            }

            // Add to the list of controls in correct order
            if (maxIndex > -1)
            {
                var loopTo = maxIndex;
                for (i = 0; i <= loopTo; i++)
                {
                    var aControl = getControlFromName(ref frmControls, controlName, i, separator);
                    if (aControl is not null)
                    {
                        // Save the object Type (uses the last control found as the Type)
                        controlType = aControl.GetType();
                    }
                    alist.Add(aControl);
                }
            }

            return alist.ToArray(controlType);

        }

        private static Control getControlFromName(ref Collection frm, string controlName, short index, string separator)
        {

            controlName = controlName + separator + index;
            foreach (Control ctl in frm)
            {
                if (string.Compare(ctl.Name, controlName, true) == 0)
                {
                    return ctl;
                }
            }

            return null;  // Could not find this control by name
        }

        private static bool IsInteger(string Value)
        {

            if (string.IsNullOrEmpty(Value))
                return false;

            foreach (char chr in Value)
            {
                if (!char.IsDigit(chr))
                {
                    return false;
                }
            }
            return true;
        }

    }

    public class ControlsCollection
    {

        private static Collection m_controls;
        public ControlsCollection(Form myForm)
        {
            m_controls = new Collection();
            // create a control walker to get 
            // all controls on the form
            var aControlWalker = new ControlWalker(myForm);

        }
        // This property returns the collection of all controls on the form
        public Collection Controls
        {
            get
            {
                return m_controls;
            }
        }

        private class ControlWalker
        {
            // This class recursively walks through all controls 
            // in a container, and all containers contained in 
            // this container, visiting all controls throughout 
            // the hierarchy
            private object mContainer;

            public ControlWalker(Control Container)
            {

                if (Container.HasChildren == true)
                {
                    foreach (Control cControl in Container.Controls)
                    {
                        // add this control to the controls collection
                        m_controls.Add(cControl);
                        if (cControl.HasChildren)
                        {
                            // This control has children, create another
                            // ControlWalk go visit each of them
                            var cWalker = new ControlWalker(cControl);
                        }
                    }
                }
            }

        }
    }
}