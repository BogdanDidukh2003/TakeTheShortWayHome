using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A sorted linked list
/// </summary>
public class SortedLinkedList<T> : LinkedList<T> where T:IComparable
{
    #region Constructor

    public SortedLinkedList() : base()
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adds the given item to the list
    /// </summary>
    /// <param name="item">item to add to list</param>
    public void Add(T item)
    {
        LinkedListNode<T> currentNode = First;
        while (currentNode != null)
        {
            if (currentNode.Value.CompareTo(item) >= 0)
            {
                AddBefore(currentNode, item);
                return;
            }

            currentNode = currentNode.Next;
        }
        AddLast(item);
    }

    /// <summary>
    /// Repositions the given item in the list by moving it
    /// forward in the list until it's in the correct
    /// position. This is necessary to keep the list sorted
    /// when the value of the item changes
    /// </summary>
    public void Reposition(T item)
    {
        Remove(item);
        Add(item);
    }

    #endregion
}
