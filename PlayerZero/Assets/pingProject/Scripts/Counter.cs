using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using System;

public class Counter : MonoBehaviour
{
	public BehaviorTree behaviorTree;
	public TextMesh counterText;
	public static int y;   // send y to instantiateV2


	void Start()
	{
		
	}
	
	void Update()
	{
		counterText.text = behaviorTree.GetVariable("Count").GetValue().ToString();
		y = Convert.ToInt32(counterText.text);
	}
}