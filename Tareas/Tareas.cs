using System.Text.Json.Serialization;

namespace espacioTarea
{
    class Tarea
    {

        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("completed")]
        public bool Estado { get; set; }
    }
}
/*
public class Tarea
{
  private int userId;
  private int id;
  private string title;
  private bool completed;
  public Tarea(int userId, int id, string title, bool completed)
  {
    this.userId = userId;
    this.id = id;
    this.title = title;
    this.completed = completed;
  }

  [JsonPropertyName("userId")]
  public int UserId { get => userId; set => userId = value; }
  [JsonPropertyName("id")]
  public int Id { get => id; set => id = value; }
  [JsonPropertyName("title")]
  public string Title { get => title; set => title = value; }
  [JsonPropertyName("completed")]
  public bool Completed { get => completed; set => completed = value; }
}*/