namespace MediaFileMetaRenamer.MetadataProviders.Abstractions;

public record MetadataInfo
{
    public required string OriginalFileName { get; init; }
}
