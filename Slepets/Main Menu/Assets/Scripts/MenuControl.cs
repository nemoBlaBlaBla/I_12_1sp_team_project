using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour 
{
	public bool isPlayButton = false;
	public bool isExitButton = false;
	
	public Color onMouseEnterColor;
	public Color onMouseExitColor;
	
	// Use this for initialization
	void Start () {
		onMouseEnterColor = new Color(renderer.material.GetColor("_Color").b,renderer.material.GetColor("_Color").g,renderer.material.GetColor("_Color").r);
		onMouseExitColor = new Color(renderer.material.GetColor("_Color").r,renderer.material.GetColor("_Color").g,renderer.material.GetColor("_Color").b);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter()
	{
		renderer.material.color = onMouseEnterColor;

	}
	
	void OnMouseExit()
	{
		renderer.material.color = onMouseExitColor;			
	}
	
	void OnMouseUp()
	{
		if(isPlayButton)
		{
			Application.LoadLevel(1);
		}
		else if(isExitButton)
		{
			Application.Quit();
		}
		
	}
}
