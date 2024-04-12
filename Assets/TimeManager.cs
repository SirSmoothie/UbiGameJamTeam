using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private int dayNumber = 1;
    [SerializeField] private int weekLength = 3;
    [SerializeField] private int weekNumber = 3;
    private bool survivedWeek;
    
    private static TimeManager _current;
    public static TimeManager Current { get { return _current; } }
    private void Awake()
    {
        if (_current != null && _current != this)
        {
            Destroy(this.gameObject);
        } else {
            _current = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void EndDay()
    {
        dayNumber++;
        if (dayNumber > weekLength)
        {
            EndWeek();
            return;
        }

        StartCoroutine(EndDayRoutine());
        return;
    }

    public void EndWeek()
    {
        dayNumber = 1;
        StartCoroutine(EndWeekRoutine());
    }
    public int ReturnDayNumber()
    {
        return dayNumber;
    }

    public int ReturnWeekNumber()
    {
        return weekNumber;
    }

    public delegate void startFading();

    public event startFading startFadingEvent;

    public void InactFade()
    {
        startFadingEvent?.Invoke();
    }
    public delegate void startUnFading();

    public event startUnFading startUnFadingEvent;

    public void UnInactFade()
    {
        startUnFadingEvent?.Invoke();
    }
    IEnumerator EndDayRoutine()
    {
        InactFade();
        yield return new WaitForSeconds(1f);
        
        yield return new WaitForSeconds(1f);
        UnInactFade();
    }
    IEnumerator EndWeekRoutine()
    {
        InactFade();
        ChangeWeek();
        yield return new WaitForSeconds(1f);
        
        yield return new WaitForSeconds(1f);
        if (survivedWeek == false)
        {
            
            yield break;
        }

        if (survivedWeek)
        {
            UnInactFade();
            survivedWeek = false;
            weekNumber++;
        }
    }
    
    public delegate void EndOfWeek();

    public event EndOfWeek EndOfWeekEvent;

    public void ChangeWeek()
    {
        EndOfWeekEvent?.Invoke();
    }

    public void SurvivedWeek()
    {
        survivedWeek = true;
    }
}
