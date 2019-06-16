using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

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

                // Run sass from the command line

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "sass";
                startInfo.Arguments = "--style expanded --cache-location " + Application.temporaryCachePath
                    + " --sourcemap=none "
                    + fileName + ".sass " + fileName + ".css";

                Process.Start(startInfo);
            }
        }
    }
}