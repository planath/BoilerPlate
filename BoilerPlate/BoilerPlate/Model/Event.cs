﻿using System;

namespace BoilerPlate.Model
{
    public class Event
    {
        public Event(string title, string description, DateTime dateTime, Category category)
        {
            Title = title;
            Description = description;
            DateTime = dateTime;
            Category = category;
            Participate = false;
        }

        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public DateTime DateTime { get; internal set; }
        public Category Category { get; internal set; }
        public bool Participate { get; set; }
    }
}
