/* ----------------------------------------------------------------------------
MIT License

Copyright (c) 2018-2023 Christopher Whitley

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
---------------------------------------------------------------------------- */

using System.ComponentModel;
using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Aseprite.AsepriteTypes;
using MonoGame.Aseprite.Content.Processors;
using MonoGame.Aseprite.RawTypes;

namespace MonoGame.Aseprite.Content.Pipeline.Processors;

/// <summary>
///     Defines a content processor that processes a <see cref="RawSpriteSheet"/> from an aseprite file that was 
///     imported.
/// </summary>
[ContentProcessor(DisplayName = "Aseprite Spritesheet Processor - MonoGame.Aseprite")]
internal sealed class SpriteSheetContentProcessor : ContentProcessor<ContentImporterResult, ContentProcessorResult<RawSpriteSheet>>
{
    /// <summary>
    ///     Gets or Sets a value that indicates whether only <see cref="AsepriteCel"/> elements on visible
    ///     <see cref="AsepriteLayer"/> elements should be included.
    /// </summary>
    [DisplayName("Only Visible Layers")]
    public bool OnlyVisibleLayers { get; set; } = true;

    /// <summary>
    ///     Gets or Sets a value that indicates whether <see cref="AsepriteCel"/> elements on an 
    ///     <see cref="AsepriteLayer"/> marked as the background layer should be included.
    /// </summary>
    [DisplayName("Include Background Layer")]
    public bool IncludeBackgroundLayer { get; set; } = false;

    /// <summary>
    ///     Gets or Sets a value that indicates whether <see cref="AsepriteCel"/> elements  on an 
    ///     <see cref="AsepriteTilemapLayer"/> element should be included.
    /// </summary>
    [DisplayName("Include Tilemap Layers")]
    public bool IncludeTilemapLayers { get; set; } = true;

    /// <summary>
    ///     Gets or Sets a value that indicates if duplicate <see cref="AsepriteFrame"/> elements should be merged into
    ///     one.
    /// </summary>
    [DisplayName("Merge Duplicate Frames")]
    public bool MergeDuplicateFrames { get; set; } = true;

    /// <summary>
    ///     Gets or Sets the amount of transparent pixels to add between the edge of the generate source image and the
    ///     regions within it.
    /// </summary>
    [DisplayName("Border Padding")]
    public int BorderPadding { get; set; } = 0;

    /// <summary>
    ///     Gets or Sets the amount of transparent pixels to add between each region in the generated source image.
    /// </summary>
    [DisplayName("Spacing")]
    public int Spacing { get; set; } = 0;

    /// <summary>
    ///     Gets or Sets the amount of transparent pixels to add around the edge of each region in the generated source
    ///     image.
    /// </summary>
    [DisplayName("Inner Padding")]
    public int InnerPadding { get; set; } = 0;

    /// <summary>
    ///     Processes a <see cref="RawSpriteSheet"/> from the contents of an <see cref="AsepriteFile"/>.
    /// </summary>
    /// <param name="content">
    ///     The <see cref="ContentImporterResult"/> from the import process.
    /// </param>
    /// <param name="context">
    ///     The content processor context that provides contextual information about the content being processed.
    /// </param>
    /// <returns>
    ///     A new <see cref="ContentProcessorResult{T}"/> containing the <see cref="RawSpriteSheet"/> created by this 
    ///     method.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if <see cref="AsepriteTag"/> elements are found in the <see cref="AsepriteFile"/> with duplicate 
    ///     names.  Spritesheets must contain <see cref="AsepriteTag"/> elements with unique names even though aseprite
    ///     does not enforce unique names for <see cref="AsepriteTag"/> elements.
    /// </exception>
    public override ContentProcessorResult<RawSpriteSheet> Process(ContentImporterResult content, ContentProcessorContext context)
    {
        AsepriteFile aseFile = AsepriteFile.Load(content.Path);
        RawSpriteSheet sheet = RawSpriteSheetProcessor.Process(aseFile, OnlyVisibleLayers, IncludeBackgroundLayer, IncludeTilemapLayers, MergeDuplicateFrames, BorderPadding, Spacing, InnerPadding);
        return new(sheet);
    }
}
