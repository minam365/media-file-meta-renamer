using MediaFileMetaRenamer.MetadataProviders.Abstractions;

namespace MediaFileMetaRenamer.MetadataProviders;

public interface IMetadataProvider
{
    MetadataProviderResult GetMetadata(string filePath);

}
