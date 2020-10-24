﻿using System;
using System.Collections.Generic;
using Hai.ComboGesture.Scripts.Editor.EditorUI.Effectors;
using UnityEngine;

namespace Hai.ComboGesture.Scripts.Editor.EditorUI
{
    public class CgeActivityEditorDriver
    {
        private static readonly Dictionary<string, string> Translations = new Dictionary<string, string>
        {
            {"anim00", "No gesture"},
            {"anim01", "Fist"},
            {"anim02", "Open"},
            {"anim03", "Point"},
            {"anim04", "Victory"},
            {"anim05", "RockNRoll"},
            {"anim06", "Gun"},
            {"anim07", "ThumbsUp"},
            {"anim11", "Fist x2, L+R trigger"},
            {"anim11_L", "Fist x2, LEFT trigger"},
            {"anim11_R", "Fist x2, RIGHT trigger"},
            {"anim12", "Open + Fist"},
            {"anim13", "Point + Fist"},
            {"anim14", "Victory + Fist"},
            {"anim15", "RockNRoll + Fist"},
            {"anim16", "Gun + Fist"},
            {"anim17", "ThumbsUp + Fist"},
            {"anim22", "Open x2"},
            {"anim23", "Open + Point"},
            {"anim24", "Open + Victory"},
            {"anim25", "Open + RockNRoll"},
            {"anim26", "Open + Gun"},
            {"anim27", "Open + ThumbsUp"},
            {"anim33", "Point x2"},
            {"anim34", "Point + Victory"},
            {"anim35", "Point + RockNRoll"},
            {"anim36", "Point + Gun"},
            {"anim37", "Point + ThumbsUp"},
            {"anim44", "Victory x2"},
            {"anim45", "Victory + RockNRoll"},
            {"anim46", "Victory + Gun"},
            {"anim47", "Victory + ThumbsUp"},
            {"anim55", "RockNRoll x2"},
            {"anim56", "RockNRoll + Gun"},
            {"anim57", "RockNRoll + ThumbsUp"},
            {"anim66", "Gun x2"},
            {"anim67", "Gun + ThumbsUp"},
            {"anim77", "ThumbsUp x2"},
            {"viseme0", "sil (0)"},
            {"viseme1", "PP (1)"},
            {"viseme2", "FF (2)"},
            {"viseme3", "TH (3)"},
            {"viseme4", "DD (4)"},
            {"viseme5", "kk (5)"},
            {"viseme6", "CH (6)"},
            {"viseme7", "SS (7)"},
            {"viseme8", "nn (8)"},
            {"viseme9", "RR (9)"},
            {"viseme10", "aa (10)"},
            {"viseme11", "E (11)"},
            {"viseme12", "ih (12)"},
            {"viseme13", "oh (13)"},
            {"viseme14", "ou (14)"},

            {"p_anim00", "None x2"},
            {"p_anim01", "None > Fist"},
            {"p_anim02", "None > Open"},
            {"p_anim03", "None > Point"},
            {"p_anim04", "None > Victory"},
            {"p_anim05", "None > RockNRoll"},
            {"p_anim06", "None > Gun"},
            {"p_anim07", "None > ThumbsUp"},

            {"p_anim10", "Fist > None"},
            {"p_anim11", "Fist x2"},
            {"p_anim11_L", "Fist x2, LEFT trigger"},
            {"p_anim11_R", "Fist x2, RIGHT trigger"},
            {"p_anim12", "Fist > Open"},
            {"p_anim13", "Fist > Point"},
            {"p_anim14", "Fist > Victory"},
            {"p_anim15", "Fist > RockNRoll"},
            {"p_anim16", "Fist > Gun"},
            {"p_anim17", "Fist > ThumbsUp"},

            {"p_anim20", "Open > None"},
            {"p_anim21", "Open > Fist"},
            {"p_anim22", "Open x2"},
            {"p_anim23", "Open > Point"},
            {"p_anim24", "Open > Victory"},
            {"p_anim25", "Open > RockNRoll"},
            {"p_anim26", "Open > Gun"},
            {"p_anim27", "Open > ThumbsUp"},

            {"p_anim30", "Point > None"},
            {"p_anim31", "Point > Fist"},
            {"p_anim32", "Point > Open"},
            {"p_anim33", "Point x2"},
            {"p_anim34", "Point > Victory"},
            {"p_anim35", "Point > RockNRoll"},
            {"p_anim36", "Point > Gun"},
            {"p_anim37", "Point > ThumbsUp"},

            {"p_anim40", "Victory > None"},
            {"p_anim41", "Victory > Fist"},
            {"p_anim42", "Victory > Open"},
            {"p_anim43", "Victory > Point"},
            {"p_anim44", "Victory x2"},
            {"p_anim45", "Victory > RockNRoll"},
            {"p_anim46", "Victory > Gun"},
            {"p_anim47", "Victory > ThumbsUp"},

            {"p_anim50", "RockNRoll > None"},
            {"p_anim51", "RockNRoll > Fist"},
            {"p_anim52", "RockNRoll > Open"},
            {"p_anim53", "RockNRoll > Point"},
            {"p_anim54", "RockNRoll > Victory"},
            {"p_anim55", "RockNRoll x2"},
            {"p_anim56", "RockNRoll > Gun"},
            {"p_anim57", "RockNRoll > ThumbsUp"},


            {"p_anim60", "Gun > None"},
            {"p_anim61", "Gun > Fist"},
            {"p_anim62", "Gun > Open"},
            {"p_anim63", "Gun > Point"},
            {"p_anim64", "Gun > Victory"},
            {"p_anim65", "Gun > RockNRoll"},
            {"p_anim66", "Gun x2"},
            {"p_anim67", "Gun > ThumbsUp"},

            {"p_anim70", "ThumbsUp > None"},
            {"p_anim71", "ThumbsUp > Fist"},
            {"p_anim72", "ThumbsUp > Open"},
            {"p_anim73", "ThumbsUp > Point"},
            {"p_anim74", "ThumbsUp > Victory"},
            {"p_anim75", "ThumbsUp > RockNRoll"},
            {"p_anim76", "ThumbsUp > Gun"},
            {"p_anim77", "ThumbsUp x2"},
        };

        private static readonly Dictionary<string, MergePair> ParameterToMerge = new Dictionary<string, MergePair>
        {
            {"anim12", new MergePair("anim01", "anim02")},
            {"anim13", new MergePair("anim01", "anim03")},
            {"anim14", new MergePair("anim01", "anim04")},
            {"anim15", new MergePair("anim01", "anim05")},
            {"anim16", new MergePair("anim01", "anim06")},
            {"anim17", new MergePair("anim01", "anim07")},
            {"anim23", new MergePair("anim02", "anim03")},
            {"anim24", new MergePair("anim02", "anim04")},
            {"anim25", new MergePair("anim02", "anim05")},
            {"anim26", new MergePair("anim02", "anim06")},
            {"anim27", new MergePair("anim02", "anim07")},
            {"anim34", new MergePair("anim03", "anim04")},
            {"anim35", new MergePair("anim03", "anim05")},
            {"anim36", new MergePair("anim03", "anim06")},
            {"anim37", new MergePair("anim03", "anim07")},
            {"anim45", new MergePair("anim04", "anim05")},
            {"anim46", new MergePair("anim04", "anim06")},
            {"anim47", new MergePair("anim04", "anim07")},
            {"anim56", new MergePair("anim05", "anim06")},
            {"anim57", new MergePair("anim05", "anim07")},
            {"anim67", new MergePair("anim06", "anim07")},


            {"anim21", new MergePair("anim10", "anim20")},
            {"anim31", new MergePair("anim10", "anim30")},
            {"anim41", new MergePair("anim10", "anim40")},
            {"anim51", new MergePair("anim10", "anim50")},
            {"anim61", new MergePair("anim10", "anim60")},
            {"anim71", new MergePair("anim10", "anim70")},
            {"anim32", new MergePair("anim20", "anim30")},
            {"anim42", new MergePair("anim20", "anim40")},
            {"anim52", new MergePair("anim20", "anim50")},
            {"anim62", new MergePair("anim20", "anim60")},
            {"anim72", new MergePair("anim20", "anim70")},
            {"anim43", new MergePair("anim30", "anim40")},
            {"anim53", new MergePair("anim30", "anim50")},
            {"anim63", new MergePair("anim30", "anim60")},
            {"anim73", new MergePair("anim30", "anim70")},
            {"anim54", new MergePair("anim40", "anim50")},
            {"anim64", new MergePair("anim40", "anim60")},
            {"anim74", new MergePair("anim40", "anim70")},
            {"anim65", new MergePair("anim50", "anim60")},
            {"anim75", new MergePair("anim50", "anim70")},
            {"anim76", new MergePair("anim60", "anim70")}
        };

        private static readonly Dictionary<string, MergePair> ParameterToMergePermutations = new Dictionary<string, MergePair>
        {
            {"anim11", new MergePair("anim01", "anim10")},
            {"anim22", new MergePair("anim02", "anim20")},
            {"anim33", new MergePair("anim03", "anim30")},
            {"anim44", new MergePair("anim04", "anim40")},
            {"anim55", new MergePair("anim05", "anim50")},
            {"anim66", new MergePair("anim06", "anim60")},
            {"anim77", new MergePair("anim07", "anim70")}
        };

        private static readonly Dictionary<string, string> AnimationToCopy = new Dictionary<string, string>
        {
            {"anim11", "anim01"},
            {"anim22", "anim02"},
            {"anim33", "anim03"},
            {"anim44", "anim04"},
            {"anim55", "anim05"},
            {"anim66", "anim06"},
            {"anim77", "anim07"},

            {"anim12", "anim02"},
            {"anim13", "anim03"},
            {"anim14", "anim04"},
            {"anim15", "anim05"},
            {"anim16", "anim06"},
            {"anim17", "anim07"},

            {"anim21", "anim20"},
            {"anim31", "anim30"},
            {"anim41", "anim40"},
            {"anim51", "anim50"},
            {"anim61", "anim60"},
            {"anim71", "anim70"},
        };

        private readonly CgeEditorEffector _editorEffector;

        public CgeActivityEditorDriver(CgeEditorEffector editorEffector)
        {
            _editorEffector = editorEffector;
        }

        public bool IsSymmetrical(string propertyPath)
        {
            return Translations[propertyPath].Contains("x2");
        }

        public string ShortTranslation(string propertyPath)
        {
            return Translations[propertyPath];
        }

        public bool IsAPropertyThatCanBeCombined(string propertyPath, bool usePermutations = false)
        {
            return ParameterToMerge.ContainsKey(propertyPath) || usePermutations && ParameterToMergePermutations.ContainsKey(propertyPath);
        }

        public bool AreCombinationSourcesDefinedAndCompatible(string propertyPath, bool usePermutations = false)
        {
            if (!IsAPropertyThatCanBeCombined(propertyPath, usePermutations))
            {
                return false;
            }

            var mergePair = !usePermutations
                ? ParameterToMerge[propertyPath]
                : (ParameterToMerge.ContainsKey(propertyPath) ? ParameterToMerge[propertyPath] : ParameterToMergePermutations[propertyPath]);
            var left = _editorEffector.SpProperty(mergePair.Left).objectReferenceValue;
            var right = _editorEffector.SpProperty(mergePair.Right).objectReferenceValue;

            return left is AnimationClip && right is AnimationClip && left != right;
        }

        public bool AreCombinationSourcesIdentical(string propertyPath)
        {
            if (!IsAPropertyThatCanBeCombined(propertyPath))
            {
                return false;
            }

            var mergePair = ParameterToMerge[propertyPath];
            var left = _editorEffector.SpProperty(mergePair.Left).objectReferenceValue;
            var right = _editorEffector.SpProperty(mergePair.Right).objectReferenceValue;

            return left != null && right != null && left == right;
        }

        public MergePair ProvideCombinationPropertySources(string propertyPath, bool usePermutations = false)
        {
            if (!IsAPropertyThatCanBeCombined(propertyPath, usePermutations))
            {
                throw new ArgumentException();
            }

            return ParameterToMerge.ContainsKey(propertyPath) ? ParameterToMerge[propertyPath] : ParameterToMergePermutations[propertyPath];
        }

        public bool IsAutoSettable(string propertyPath)
        {
            return AnimationToCopy.ContainsKey(propertyPath);
        }

        public string GetAutoSettableSource(string propertyPath)
        {
            return AnimationToCopy[propertyPath];
        }
    }

    public readonly struct MergePair
    {
        public MergePair(string left, string right)
        {
            Left = left;
            Right = right;
        }

        internal string Left { get; }
        internal string Right { get; }
    }
}
