// See https://aka.ms/new-console-template for more information
using MediaFileMetaRenamer.MetadataProviders;

Console.WriteLine("Hello, World!");

var filePath = @"C:\Users\minam\OneDrive\Pictures\-- to be archived\2001\14.12.2001 12-34-10.jpg";

IMetadataProvider metadataProvider = new MetadataProvider();
var metadataResult = metadataProvider.GetMetadata(filePath);
Console.WriteLine($"File1: {metadataResult}");

var file2 = @"C:\Users\minam\OneDrive\Pictures\-- to be archived\iphone 14 pro\camera\202309__\IMG_3942.JPG";
metadataResult = metadataProvider.GetMetadata(file2);
Console.WriteLine($"File2: {metadataResult}");

var file3 = @"C:\Users\minam\OneDrive\Pictures\-- to be archived\iphone 14 pro\DCIM\202205__\YIYI7857.MP4";
metadataResult = metadataProvider.GetMetadata(file3);
Console.WriteLine($"File3: {metadataResult}");