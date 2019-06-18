using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Diagnostics;
using SharpScss;
using System.IO;

namespace Eidetic.Editor.Sass
{
    class SassProcessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            var sassFilePaths = importedAssets
                .Where(filePath => filePath.Split('.')[1] == "sass");

            foreach (var filePath in sassFilePaths)
            {
                var fileName = filePath.Split('.')[0];
                var result = Scss.ConvertFileToCss(fileName + ".sass", new ScssOptions() {
                    GenerateSourceMap = false, OutputStyle = ScssOutputStyle.Expanded
                });
                File.WriteAllText(fileName + ".uss", result.Css);
            }
        }
    }
}