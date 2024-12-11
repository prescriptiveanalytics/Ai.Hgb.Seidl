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
  public record NodeRecord(string name);
  public record EdgeRecord(string name, string from, string to, string type, string payload);
  public record GraphRecord(IEnumerable<NodeRecord> nodes, IEnumerable<EdgeRecord> edges);

  public record InitializationRecordOld(string name, string typeImageName, string typeImageTag, string parameterJson, RoutingTable routing);

  public record InitializationRecord(string name, string typeImageName, string typeImageTag, Dictionary<string, object> parameters, RoutingTable routing);
}
