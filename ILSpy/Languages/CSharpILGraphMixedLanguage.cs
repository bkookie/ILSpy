using System.Composition;

using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Disassembler;

namespace ICSharpCode.ILSpy.Languages
{
	[Export(typeof(Language))]
	[Shared]
	[method: ImportingConstructor]
	class CSharpILGraphMixedLanguage(SettingsService settingsService) : CSharpILMixedLanguage(settingsService)
	{
		public override string Name => "IL CDFG with C#";

		protected override ReflectionDisassembler CreateDisassembler(ITextOutput output, DecompilationOptions options)
		{
			ReflectionDisassembler dis = base.CreateDisassembler(output, options);
			dis.BuildControlDataFlowGraph = true;
			dis.LeftAlignCommentsAndAnnotations = SettingsService.DisplaySettings.LeftAlignCommentsAndAnnotations;
			dis.ShowStackDepth = SettingsService.DisplaySettings.ShowStackDepth;
			return dis;
		}
	}
}
