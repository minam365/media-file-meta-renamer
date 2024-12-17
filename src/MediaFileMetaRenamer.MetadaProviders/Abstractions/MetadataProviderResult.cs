using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaFileMetaRenamer.MetadataProviders.Abstractions;

public record MetadataProviderResult
{
    public bool IsSucceeded { get; set; }
    public required string StatusMessage { get; set; }

    public MetadataInfo? Metadata { get; init; } = null;

}
