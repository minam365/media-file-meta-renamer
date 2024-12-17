using CommunityToolkit.Diagnostics;

using MediaFileMetaRenamer.MetadataProviders.Abstractions;

using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.FileSystem;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Directory = MetadataExtractor.Directory;

namespace MediaFileMetaRenamer.MetadataProviders;

public class MetadataProvider : IMetadataProvider
{
    public MetadataProviderResult GetMetadata(string filePath)
    {
        IEnumerable<Directory> directories;

        try
        {
            Guard.IsNotNull(filePath);
            Guard.IsNotNullOrWhiteSpace(filePath);

            ExifMetadataInfo? exifMetadata = null;

            directories = ImageMetadataReader.ReadMetadata(filePath);
            foreach (var dir in directories)
            {
                
                if (dir is ExifIfd0Directory exifIfd0Directory && exifIfd0Directory is not null)
                {
                    exifMetadata = new ExifMetadataInfo(Make: exifIfd0Directory.GetString(ExifDirectoryBase.TagMake),
                                                        Model: exifIfd0Directory.GetString(ExifDirectoryBase.TagModel),
                                                        DateDigitized: exifIfd0Directory.GetDateTime(ExifDirectoryBase.TagDateTime));
                }
            }

            FileInfo fileInfo = new FileInfo(filePath);
            FileMetadataInfo fileMetadata = new FileMetadataInfo(FileName: fileInfo.Name, FileSize: fileInfo.Length, fileInfo.LastWriteTime);

            var result = new MetadataProviderResult
            {
                IsSucceeded = true,
                StatusMessage = $"Successfully read metadata information from file '{filePath}'",
                Metadata = new MetadataInfo(fileMetadata, exifMetadata)
            };

            return result;
        }
        catch (Exception e)
        {
            var result = new MetadataProviderResult
            {
                IsSucceeded = false,
                StatusMessage = e.Message
            };

            return result;
        }

    }

    
}
