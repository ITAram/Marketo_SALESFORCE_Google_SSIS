// Copyright 2011, Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Author: api.anash@gmail.com (Anash P. Oommen)

using System;
using System.Collections.Generic;
using System.Reflection;

namespace AdWordsImport.Examples.CSharp {
  /// <summary>
  /// Utility class for assisting in running code examples.
  /// </summary>
  public class ExampleUtilities {
    /// <summary>
    /// Gets a random string. Useful for generating unique names for campaigns,
    /// ad groups, etc.
    /// </summary>
    /// <returns>The current timestamp as a string.</returns>
    public static string GetRandomString() {
      return string.Format("{0} - {1}", Guid.NewGuid(),
          DateTime.Now.ToString("yyyy-M-d H-m-s.ffffff"));
    }

    /// <summary>
    /// Formats the exception as a printable message.
    /// </summary>
    /// <param name="ex">The exception.</param>
    /// <returns>The formatted exception string.</returns>
    public static string FormatException(Exception ex) {
      List<String> messages = new List<string>();
      Exception rootEx = ex;
      while (rootEx != null) {
        messages.Add(String.Format("{0} ({1})\n\n{2}\n", rootEx.GetType().ToString(),
            rootEx.Message, rootEx.StackTrace));
        rootEx = rootEx.InnerException;
      }
      return String.Join("\nCaused by\n\n", messages.ToArray());
    }

    /// <summary>
    /// Gets the current user's home directory.
    /// </summary>
    /// <returns>The current user's home directory.</returns>
    public static String GetHomeDir() {
      return Environment.GetEnvironmentVariable("USERPROFILE");
    }

    /// <summary>
    /// Gets the parameters for running the code example.
    /// </summary>
    /// <param name="methodInfo">The method info for Run method in code
    /// example.</param>
    /// <returns>An array of parameters for running the code example.</returns>
    public static List<object> GetParameters(MethodInfo methodInfo) {
      List<object> retval = new List<object>();
      ParameterInfo[] paramInfos = methodInfo.GetParameters();
      for (int i = 1; i < paramInfos.Length; i++) {
        ParameterInfo paramInfo = paramInfos[i];
        Console.Write("Enter {0}: ", paramInfo.Name);
        string value = Console.ReadLine();
        object objValue = null;
        if (paramInfo.ParameterType == typeof(long)) {
          objValue = long.Parse(value);
        } else if (paramInfo.ParameterType == typeof(double)) {
          objValue = double.Parse(value);
        } else if (paramInfo.ParameterType == typeof(string)) {
          objValue = value;
        } else if (paramInfo.ParameterType.IsEnum) {
          objValue = Enum.Parse(paramInfo.ParameterType, value);
        } else {
          throw new ApplicationException("Unknown parameter type : " +
              paramInfo.ParameterType.FullName);
        }
        retval.Add(objValue);
      }
      return retval;
    }
  }
}
