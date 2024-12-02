using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class View : MonoBehaviour
{
	[SerializeField]
	private bool isTransition = false;
	public bool IsTransition {  get { return isTransition; } }

	[SerializeField]
	private float trasitionTimeInSeconds = 2.0f;
	public float TrasitionTimeInSeconds { get {  return trasitionTimeInSeconds; } }

	[SerializeField]
	private View viewToTransitionTo;
	public View ViewToTransitionTo {  get { return viewToTransitionTo; } }

	[SerializeField]
	private UnityEvent onViewShowListeners;


	/// <summary>
	/// Event method to be called when the view is shown.
	/// </summary>
	public void OnShowView()
	{
		InvokeOnViewShowListeners();
	}

	private void InvokeOnViewShowListeners()
	{
		onViewShowListeners.Invoke();
	}

}