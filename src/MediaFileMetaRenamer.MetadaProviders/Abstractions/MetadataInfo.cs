namespace MediaFileMetaRenamer.MetadataProviders.Abstractions;

public record MetadataInfo(FileMetadataInfo? FileMetadata, ExifMetadataInfo? ExifMetadata);
