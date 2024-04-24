using Microsoft.ClearScript.V8;
using System;

namespace NetJsScriptBridge
{
    public static class JsScriptParser
    {
        // Executes JavaScript script to parse a DateTime object
        public static DateTime ParseDateTime(string script)
        {
            // Create an instance of V8 engine
            using var engine = new V8ScriptEngine();

            // Execute script to define a function returning a Date object
            engine.Execute("function parseDate() { return " + script + "; }");
            var result = engine.Script.parseDate();

            // Convert result from JavaScript Date object to UTC milliseconds
            var milliseconds = engine.Evaluate("parseDate().getTime()");

            // Convert UTC milliseconds to DateTime
            return DateTimeOffset.FromUnixTimeMilliseconds((long)milliseconds).UtcDateTime;
        }
    }
}
