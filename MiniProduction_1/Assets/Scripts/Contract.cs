using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract {

	Stack[] stacks;

	Contract(int numberOfStacks)
	{
		stacks = new Stack[numberOfStacks];
	}
	public int GetNumberOfStacks()
	{
		return stacks.Length;
	}
}
