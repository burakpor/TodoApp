using System;
using System.Collections.Generic;
using TodoApp.Models.EntityModels;

namespace TodoApp.Models.BusinessModels
{
    public class GetCategoryResponse : ResponseBase
    {
        public Category CategoryObj { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public bool IsResponseTypeList { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Todo> TodoList { get; set; }
    }
}
