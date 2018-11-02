namespace Qualysoft.Evaluation.Application
{
    /// <summary>General input to output reference type mapper</summary>
    /// <typeparam name="TInput">input type</typeparam>
    /// <typeparam name="TOutput">output class type</typeparam>
    /// <remarks>I don't like AutoMapper. Too much reflection and confusion.</remarks>
    public interface IClassMapper<in TInput, out TOutput>
        where TInput : class
        where TOutput : class
    {
        TOutput Map(TInput @input);
    }
}
