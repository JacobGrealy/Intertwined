using UnityEngine;
using System.Collections;

public class LineCharger : MonoBehaviour {

    public float BaseChargeRate = 1;
    public float ChargeGrowthRate;
    public float CurrentChargeRate { get; private set; }
    public float DischargeRate = 2;
	public float MinimumFrequencyIncreaseRate =.5f;
    public float ScorePerLevel = 20;
    public int Level;

    private LineManager Manager;
    private BallBehaviour Ball;
    private float MinimumFrequency;
    private float MaximumFrequency;
    private float TargetFrequency;

	// Use this for initialization
	void Start () {
        Manager = GameObject.FindObjectOfType<LineManager>();
        Ball = GameObject.FindObjectOfType<BallBehaviour>();
        MinimumFrequency = Manager.frequency1;
        if (MaximumFrequency <= 0) MaximumFrequency = float.MaxValue;
        Level = (int)(Ball.ScoreTimer / ScorePerLevel);
        TargetFrequency = Manager.frequency1;

        ResetChargeRate();
	}
	
	// Update is called once per frame
	void Update () {
        //DischargeInactiveLine();
        //ChargeActiveLine();
        //UpdateChargeRate();
        //IncreaseMinimumFrequency ();
        if ((Ball.ScoreTimer / ScorePerLevel) > Level)
        {
            LevelUpCharge();
        }
        GradualLevelUp();
	}

	void IncreaseMinimumFrequency()
	{
		MinimumFrequency += Time.deltaTime * MinimumFrequencyIncreaseRate;
		if (MinimumFrequency >= MaximumFrequency)
		{
			MinimumFrequency = MaximumFrequency;
		}
		Manager.frequency1 = Mathf.Max (Manager.frequency1, MinimumFrequency);
		Manager.frequency2 = Mathf.Max (Manager.frequency2, MinimumFrequency);
	}

    void DischargeInactiveLine()
    {
        //determine which line/s are inactive
        float scalingFactor = .1f;
        float normalizedDischargeRate = DischargeRate * Time.deltaTime * scalingFactor;
        if(Ball.activeLine == BallBehaviour.Lines.BLUELINE) 
			Manager.frequency1 = Mathf.Max(MinimumFrequency, Manager.frequency1 - normalizedDischargeRate);
        //if inactive
        if (Ball.activeLine == BallBehaviour.Lines.REDLINE) 
			Manager.frequency2 = Mathf.Max(MinimumFrequency, Manager.frequency2 - normalizedDischargeRate);
    }

    void ChargeActiveLine()
    {
        float scalingFactor = .1f;
        float normalizedChargeRate = CurrentChargeRate * Time.deltaTime * scalingFactor;
        //if active
        if (Ball.activeLine == BallBehaviour.Lines.REDLINE) Manager.frequency1 = Mathf.Min(MaximumFrequency, Manager.frequency1 + normalizedChargeRate);
        //if active
        if (Ball.activeLine == BallBehaviour.Lines.BLUELINE) Manager.frequency2 = Mathf.Min(MaximumFrequency, Manager.frequency2 + normalizedChargeRate);
    }

    void UpdateChargeRate()
    {
        float scalingFactor = .01f;
        CurrentChargeRate = BaseChargeRate + scalingFactor * ChargeGrowthRate * Ball.ScoreTimer;
    }

    public void ResetChargeRate()
    {
        CurrentChargeRate = BaseChargeRate;
    }

    public void LevelUpCharge()
    {
        CurrentChargeRate = BaseChargeRate;
        TargetFrequency += CurrentChargeRate;
        GradualLevelUp();
        Level++;
    }

    public void GradualLevelUp()
    {
        if (TargetFrequency > Manager.frequency1)
        {
            Manager.frequency1 += CurrentChargeRate * Time.deltaTime / 2f;
            Manager.frequency2 += CurrentChargeRate * Time.deltaTime / 2f;
        }
    }
}
