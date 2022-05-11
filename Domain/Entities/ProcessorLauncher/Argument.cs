using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProcessorLauncher
{
    //https://stackoverflow.com/questions/9908113/can-an-interface-require-a-property-but-not-specify-a-required-type

    public class Argument
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    //public interface IArgument<T>
    //{
    //    public string Key { get; set; }
    //    public T Value { get; set; }
    //    public ArgsType Type { get; }
    //}
    //public class ArgumentString<string> : IArgument<string>
    //{
    //    public string Key { get; set; }
    //    public string Value { get; set; }
    //    public ArgsType Type { get; } = ArgsType.String;
    //}
    //public class ArgumentInt : IArgument<int>
    //{
    //    public string Key { get; set; }
    //    public int Value { get; set; }
    //    public ArgsType Type { get; } = ArgsType.Int;
    //}
}
