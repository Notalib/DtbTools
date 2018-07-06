﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MacroEditor.Actions
{
    public class RenameEntryAction : IAction
    {
        public XName NewName { get; }

        public XName OldName { get; }

        public XElement ElementToRename { get; }

        public RenameEntryAction(XElement elementToRename, XName newName)
        {
            ElementToRename = elementToRename ?? throw new ArgumentNullException(nameof(elementToRename));
            NewName = newName ?? throw new ArgumentNullException(nameof(newName));
            OldName = elementToRename.Name;
        }

        public void Execute()
        {
            ElementToRename.Name = NewName;
        }

        public void UnExecute()
        {
            ElementToRename.Name = OldName;
        }

        public bool CanExecute => true;
        public bool CanUnExecute => true;
        public string Description => "Rename entry";
    }
}
