using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyComing : StudyAction
{
    public override void DoAction()
    {
        base.DoAction();
        _studyController.VisitSchool();
    }

    protected override bool IsEqualCondition()
    {
        if (_timeManagment.CurrentWeekDay == "Saturday" || _timeManagment.CurrentWeekDay == "Sunday")
            return false;
        else
            return true;
    }
}