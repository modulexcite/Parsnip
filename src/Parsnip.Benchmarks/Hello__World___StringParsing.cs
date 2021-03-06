﻿namespace Parsnip.Benchmarks
{
    using Parsers;


    public class Hello__World___StringParsing :
        StringParsing
    {
        readonly Parser<string, string> _parser;

        public Hello__World___StringParsing()
        {
            var sp = new StringParser();

            _parser = from hello in sp.String("Hello")
                      from comma in sp.Char(',')
                      from ws in sp.Whitespace()
                      from world in sp.String("World")
                      from period in sp.Char('.')
                      from nl in sp.NewLine()
                      select hello;
        }


        public void Parse(string subject)
        {
            Result<string, string> result = _parser.ParseString(subject);
        }
    }
}