using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMessages 
{
	private static Dictionary<string,string> messages;

	public static void AddMessage(string message)
	{
		if (messages == null)
			messages = new Dictionary<string, string>();

		if (!messages.ContainsKey(message))
			messages.Add(message,message);
	}

	public static bool GetMessage(string message,bool removeMessage)
	{
		if (messages == null)
			messages = new Dictionary<string, string>();

		if (!messages.ContainsKey(message))
			return false;

		if (removeMessage)
			messages.Remove(message);
		return true;
	}
}
