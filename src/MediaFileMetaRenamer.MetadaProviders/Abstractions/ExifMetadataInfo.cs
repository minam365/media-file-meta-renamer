using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaFileMetaRenamer.MetadataProviders.Abstractions;

public record ExifMetadataInfo(string Make, string Model, DateTime DateDigitized);
