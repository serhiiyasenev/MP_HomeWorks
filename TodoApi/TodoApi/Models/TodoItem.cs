﻿using System.Collections.Generic;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public List<TodoItemValue> Values { get; set; }
    }
}