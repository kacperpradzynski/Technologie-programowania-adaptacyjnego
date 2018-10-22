﻿using System;
using System.Collections.ObjectModel;

namespace Library.TreeView
{
    public class TreeViewItem
    {
        public TreeViewItem()
        {
            Children = new ObservableCollection<TreeViewItem>() { null };
            //null zeby mozna rozwinac, jezeli jest pusta to nie pojawi sie plusik
            //wypełniany w wyniku operacji rozwin
            this.m_WasBuilt = false;
        }
        public string Name { get; set; }
        public ObservableCollection<TreeViewItem> Children { get; set; }
        //rekurencja property odwołuje sie do treeviewitem
        public bool IsExpanded
            //bindowanie w dwie strony kopiowane z xamla, drzewko podstawia nowa wartość
        {
            get { return m_IsExpanded; }
            set
            {
                m_IsExpanded = value;
                if (m_WasBuilt)
                    //sprawdzamy czy poziom juz kiedys był rozwijany
                    return;
                Children.Clear();
                //clearujemy element i BuildMyself()
                BuildMyself();
                //m_WasBuilt jest tutaj zle powinno byc na koncu metody
                //m_WasBuilt = true;

            }
        }

        private bool m_WasBuilt;
        private bool m_IsExpanded;
        private void BuildMyself()
        {
            Random random = new Random();
            //nielosujemy; odwołanie do modelu obiektowego dll.
            //potrzebna informacja, który fragment modelu wyswietlamy
            for (int i = 0; i < random.Next(7); i++)
                this.Children.Add(new TreeViewItem() { Name = "sample" + i });
            //zamiast for pytamy model, daj mnie wszystkie properties foreach, metody foreach itp
            //rozwiazanie jest niepełne
            m_WasBuilt = true;
        }
    }
}