﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Library.Reflection;
using Library.Singleton;

namespace Library.TreeView
{
    public class NamespaceTI : TreeViewItem
    {

        public List<TypeMetadata> TypeList { get; set; }

        public NamespaceTI(NamespaceMetadata namespaceMetadata) : base(namespaceMetadata.Name, ItemTypeEnum.Namespace)
        {
            TypeList = namespaceMetadata.Types;
        }

        protected override void BuildMyself(ObservableCollection<TreeViewItem> children)
        {
            if (TypeList != null)
            {
                foreach (TypeMetadata typeMetadata in TypeList)
                {
                    ItemTypeEnum typeEnum = typeMetadata.Type == TypeEnum.Class ?
                        ItemTypeEnum.Class : typeMetadata.Type == TypeEnum.Enum ?
                            ItemTypeEnum.Enum : typeMetadata.Type == TypeEnum.Interface ?
                                ItemTypeEnum.Interface : ItemTypeEnum.Struct;

                    children.Add(new TypeTI(TypeSingleton.Instance.Get(typeMetadata.Name), typeEnum));
                }
            }
        }
    }
}
