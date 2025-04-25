using Ai.Hgb.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai.Hgb.Seidl.Data {

  public record LintRequest(string programText, int line, int character);
  public record LintLineRequest(string programText, string lineText, int line, int character);
  public record LintSymbolRequest(string programText, string symbolName, int line, int character);
  public record ProgramRecord(string programText);
  public record NodetypeRecord(string name, string imageName, string imageTag, string command, Dictionary<string, string> properties, Point routingPoint);
  public record NodeRecord(string name);
  public record EdgeRecord(string name, string from, string to, string type, string payload);
  public record GraphRecord(IEnumerable<NodeRecord> nodes, IEnumerable<EdgeRecord> edges);  
  public record Executable (string imageName, string imageTag, string command, string workingDirectory, string arguments);
  public record InitializationRecord(string name, Executable exe, Dictionary<string, object> parameters, RoutingTable routing);
  public record ProjectInfo(string pguid, string tguid, string name, string relpath, string relpathpfile, string abspath, string imagename, string imagetag, string command);

}
