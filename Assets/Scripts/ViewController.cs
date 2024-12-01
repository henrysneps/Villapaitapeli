using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;

public class ViewController : MonoBehaviour
{
	[SerializeField]
	private View
		startView,
		choiceView,
		happyTransitionView1,
		happyTransitionView2,
		happyGameOverView,
		unhappyTransitionView,
		unhappyGameOverView;

	private PassiveTimer viewTansitionTimer = new PassiveTimer();
	private View nextViewToTransitionTo;

	private void Start()
	{
		ShowStartView();
	}

	public void ShowStartView()
	{
		ShowView(startView);
	}

	private void ShowView(View view)
	{
		HideAllViews();
		ActivateView(view);
		HandleTransitionTimerOf(view);
		view.OnShowView();
	}

	private void HideAllViews()
	{
		DeactivateView(startView);
		DeactivateView(choiceView);
		DeactivateView(happyTransitionView1);
		DeactivateView(happyTransitionView2);
		DeactivateView(happyGameOverView);
		DeactivateView(unhappyTransitionView);
		DeactivateView(unhappyGameOverView);
	}

	private void DeactivateView(View view)
	{
		view.gameObject.SetActive(false);
	}

	private void ActivateView(View view)
	{
		view.gameObject.SetActive(true);
	}

	private void HandleTransitionTimerOf(View view)
	{
		if (view.IsTransition)
		{
			if(view.ViewToTransitionTo == null)
			{
				Debug.LogError("View has a transition but doesn't have a next view declared.");
				return;
			}
			nextViewToTransitionTo = view.ViewToTransitionTo;
			viewTansitionTimer.SetTimerFor(view.TrasitionTimeInSeconds);
		}
	}

	public void ShowChoiceView()
	{
		ShowView(choiceView);
	}

	public void ShowHappyTransitionView()
	{
		ShowView(happyTransitionView1);
	}

	public void ShowHappyGameOverView()
	{
		ShowView(happyGameOverView);
	}

	public void ShowUnhappyTransitionView()
	{
		ShowView(unhappyTransitionView);
	}

	public void ShowUnhappyGameOverView()
	{
		ShowView(unhappyGameOverView);
	}

	private void Update()
	{
		CheckTranisitionTimer();
	}

	private void CheckTranisitionTimer()
	{
		if (viewTansitionTimer.isDone() && nextViewToTransitionTo != null)
		{
			viewTansitionTimer.ResetTimer();
			ShowView(nextViewToTransitionTo);
		}
	}

}