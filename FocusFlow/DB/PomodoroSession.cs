namespace FocusFlow.DB
{
    public class PomodoroSession
    {
        public int Id { get; set; }
        public int TaskId {  get; set; }
        public DateTime StartTime;
        public int DurationMinutes { get; set; }
        public int SecondsPassed { get; set; }
        public SessionType SessionType { get; set; }
    }
}
