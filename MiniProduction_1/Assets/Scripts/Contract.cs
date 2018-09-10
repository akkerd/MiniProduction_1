using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract {

	Stack[] stacks;
	public bool isCompleted = false;
	public bool haveBeenShown = false;
	public Contract(int numberOfStacks)
	{
		stacks = new Stack[numberOfStacks];
		for (int i = 0; i < numberOfStacks; i++)
		{
			stacks[i] = new Stack(i.ToString());
		}
	}
	public int GetNumberOfStacks()
	{
		return stacks.Length;
	}
	public Stack[] GetStacks()
	{
		return stacks;
	}
}
