namespace WebAPI2_for_Vuex.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public virtual DbSet<MyTodo> MyTodos { get; set; }
    }

    public class MyTodo
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "project")]
        public string Project { get; set; }

        [JsonProperty(PropertyName = "completed")]
        public bool Completed { get; set; }

    }
}