using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;

    public GoalManager()
    {
        _goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            string goalType = parts[0];
            string[] values = parts[1].Split(',');

            switch (goalType)
            {
                case "SimpleGoal":
                    AddGoal(new SimpleGoal(values[0], values[1], int.Parse(values[2])));
                    break;
                case "EternalGoal":
                    AddGoal(new EternalGoal(values[0], values[1], int.Parse(values[2])));
                    break;
                case "ChecklistGoal":
                    var checklist = new ChecklistGoal(values[0], values[1], int.Parse(values[2]), int.Parse(values[4]), int.Parse(values[3]));
                    typeof(ChecklistGoal).GetField("_currentCount", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.SetValue(checklist, int.Parse(values[5]));
                    AddGoal(checklist);
                    break;
            }
        }
    }
}
