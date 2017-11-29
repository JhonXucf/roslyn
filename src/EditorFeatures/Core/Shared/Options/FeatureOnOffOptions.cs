﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.Options.Providers;

namespace Microsoft.CodeAnalysis.Editor.Shared.Options
{
    internal static class FeatureOnOffOptions
    {
        public static readonly PerLanguageOption<bool> EndConstruct = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(EndConstruct), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.AutoEndInsert"));

        // This value is only used by Visual Basic, and so is using the old serialization name that was used by VB.
        public static readonly PerLanguageOption<bool> AutomaticInsertionOfAbstractOrInterfaceMembers = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(AutomaticInsertionOfAbstractOrInterfaceMembers), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.AutoRequiredMemberInsert"));

        public static readonly PerLanguageOption<bool> LineSeparator = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(LineSeparator), defaultValue: false,
            storageLocations: new RoamingProfileStorageLocation(language => language == LanguageNames.VisualBasic ? "TextEditor.%LANGUAGE%.Specific.DisplayLineSeparators" : "TextEditor.%LANGUAGE%.Specific.Line Separator"));

        public static readonly PerLanguageOption<bool> Outlining = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(Outlining), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.Outlining"));

        public static readonly PerLanguageOption<bool> KeywordHighlighting = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(KeywordHighlighting), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation(language => language == LanguageNames.VisualBasic ? "TextEditor.%LANGUAGE%.Specific.EnableHighlightRelatedKeywords" : "TextEditor.%LANGUAGE%.Specific.Keyword Highlighting"));

        public static readonly PerLanguageOption<bool> ReferenceHighlighting = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(ReferenceHighlighting), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation(language => language == LanguageNames.VisualBasic ? "TextEditor.%LANGUAGE%.Specific.EnableHighlightReferences" : "TextEditor.%LANGUAGE%.Specific.Reference Highlighting"));

        public static readonly PerLanguageOption<bool> FormatOnPaste = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(FormatOnPaste), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.FormatOnPaste"));

        public static readonly PerLanguageOption<bool> AutoXmlDocCommentGeneration = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(AutoXmlDocCommentGeneration), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation(language => language == LanguageNames.VisualBasic ? "TextEditor.%LANGUAGE%.Specific.AutoComment" : "TextEditor.%LANGUAGE%.Specific.Automatic XML Doc Comment Generation"));

        public static readonly PerLanguageOption<bool> AutoInsertBlockCommentStartString = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(AutoInsertBlockCommentStartString), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.Auto Insert Block Comment Start String"));

        public static readonly PerLanguageOption<bool> PrettyListing = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(PrettyListing), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.PrettyListing"));

        public static readonly PerLanguageOption<bool> AutoFormattingOnTyping = new PerLanguageOption<bool>(
            nameof(FeatureOnOffOptions), nameof(AutoFormattingOnTyping), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.Auto Formatting On Typing"));

        public static readonly PerLanguageOption<bool> AutoFormattingOnReturn = new PerLanguageOption<bool>(
            nameof(FeatureOnOffOptions), nameof(AutoFormattingOnReturn), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.Auto Formatting On Return"));

        public static readonly PerLanguageOption<bool> AutoFormattingOnCloseBrace = new PerLanguageOption<bool>(
            nameof(FeatureOnOffOptions), nameof(AutoFormattingOnCloseBrace), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.Auto Formatting On Close Brace"));

        public static readonly PerLanguageOption<bool> AutoFormattingOnSemicolon = new PerLanguageOption<bool>(
            nameof(FeatureOnOffOptions), nameof(AutoFormattingOnSemicolon), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.Auto Formatting On Semicolon"));

        public static readonly PerLanguageOption<bool> RenameTrackingPreview = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(RenameTrackingPreview), defaultValue: true,
            storageLocations: new RoamingProfileStorageLocation(language => language == LanguageNames.VisualBasic ? "TextEditor.%LANGUAGE%.Specific.RenameTrackingPreview" : "TextEditor.%LANGUAGE%.Specific.Rename Tracking Preview"));

        /// <summary>
        /// This option is currently used by Roslyn, but we might want to implement it in the 
        /// future. Keeping the option while it's unimplemented allows all upgrade paths to 
        /// maintain any customized value for this setting, even through versions that have not
        /// implemented this feature yet.
        /// </summary>
        public static readonly PerLanguageOption<bool> RenameTracking = new PerLanguageOption<bool>(nameof(FeatureOnOffOptions), nameof(RenameTracking), defaultValue: true);

        /// <summary>
        /// This option is currently used by Roslyn, but we might want to implement it in the 
        /// future. Keeping the option while it's unimplemented allows all upgrade paths to 
        /// maintain any customized value for this setting, even through versions that have not
        /// implemented this feature yet.
        /// </summary>
        public static readonly PerLanguageOption<bool> RefactoringVerification = new PerLanguageOption<bool>(
            nameof(FeatureOnOffOptions), nameof(RefactoringVerification), defaultValue: false);

        public static readonly PerLanguageOption<bool> StreamingGoToImplementation = new PerLanguageOption<bool>(
            nameof(FeatureOnOffOptions), nameof(StreamingGoToImplementation), defaultValue: true);

        private const string LocalRegistryPath = @"Roslyn\Features\";

        public static readonly Option<bool> NavigateToDecompiledSources = new Option<bool>(
            nameof(FeatureOnOffOptions), nameof(NavigateToDecompiledSources), defaultValue: false,
            storageLocations: new LocalUserProfileStorageLocation(LocalRegistryPath + nameof(NavigateToDecompiledSources)));
    }

    [ExportOptionProvider, Shared]
    internal class FeatureOnOffOptionsProvider : IOptionProvider
    {
        public ImmutableArray<IOption> Options { get; } = ImmutableArray.Create<IOption>(
            FeatureOnOffOptions.EndConstruct,
            FeatureOnOffOptions.AutomaticInsertionOfAbstractOrInterfaceMembers,
            FeatureOnOffOptions.LineSeparator,
            FeatureOnOffOptions.Outlining,
            FeatureOnOffOptions.KeywordHighlighting,
            FeatureOnOffOptions.ReferenceHighlighting,
            FeatureOnOffOptions.FormatOnPaste,
            FeatureOnOffOptions.AutoXmlDocCommentGeneration,
            FeatureOnOffOptions.AutoInsertBlockCommentStartString,
            FeatureOnOffOptions.PrettyListing,
            FeatureOnOffOptions.AutoFormattingOnTyping,
            FeatureOnOffOptions.AutoFormattingOnReturn,
            FeatureOnOffOptions.AutoFormattingOnCloseBrace,
            FeatureOnOffOptions.AutoFormattingOnSemicolon,
            FeatureOnOffOptions.RenameTrackingPreview,
            FeatureOnOffOptions.RenameTracking,
            FeatureOnOffOptions.RefactoringVerification,
            FeatureOnOffOptions.StreamingGoToImplementation);
    }
}
