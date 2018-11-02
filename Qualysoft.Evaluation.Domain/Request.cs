namespace Qualysoft.Evaluation.Domain
{
    using System;

    /// <summary>request entity</summary>
    /// <remarks>Not defined by attributes, but by identity, <see cref="Index"/> column</remarks>
    public class Request : BaseEntity<int>, IAggregateRoot
    {
        public Request() { }

        public Request(int id, string name, DateTime date, int? visits = null)
            : base(id)
        {
            Name = name;
            Date = date;
            Visits = visits;
        }

        public string Name { get; set; }
        public int? Visits { get; set; }
        public DateTime Date { get; set; }

        public void UpdateAttributes(string name, DateTime date, int? visits)
        {
            Name = name;
            Date = date;
            Visits = visits;
        }

        public string GetDateString() => Date.ToString("yyyy-MM-dd");
    }
}
