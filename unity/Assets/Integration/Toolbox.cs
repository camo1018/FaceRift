using UnityEngine;
using System.Collections;
using System;

public class Toolbox : Singleton<Toolbox> {
	protected Toolbox() {}
	
	public string authenticationToken = "";
}
