﻿using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DSExplorer
{
    interface Context
    {
    }

    public class CCIContext : Context
    {
        public CCI cci;
        public CXI[] cxis;
        public CXIPlaingRegion[] cxiprs;
        public int currentNcch;
    }

    public class Partition
    {
        public const int HASH_LENGTH = 0x20;

        public long offsetInImage;

        public DIFI Difi;
        public IVFC Ivfc;
        public DPFS Dpfs;
        public byte[] Hash; //0x20 - SHA256

        public byte[][] HashTable;
    }

    public class SFContext : Context
    {
        public const int IMAGE_HASH_LENGTH = 0x10;

        //Wear-Level stuff

        public byte[] Key;

        public byte[] MemoryMap;
        public SFHeaderEntry[] Blockmap;
        public SFLongSectorEntry[] Journal;
        public int JournalSize;
        public SFHeader fileHeader;
        public byte[] image;
        
        //Image stuff

        public bool isData;

        public byte[] ImageHash; //0x10 - ??
        public DISA Disa;
        
        public int currentPartition;
        public Partition[] Partitions;

        public SAVE Save;
        public FileSystemEntry[] Files;
        public long fileBase;
    }

    public class TMDCertContext
    {
        
        public TMDCertificate cert;
        public TMDSignatureType SignatureType;
        public byte[] tmdSHA;
    }

    public class TMDContext : Context
    {
        public TMDHeader head;
        public TMDSignatureType SignatureType;
        public TMDContentInfoRecord[] ContentInfoRecords;
        public ArrayList chunks; // of TMDContentChunkRecord
        public byte[] tmdSHA;

        public ArrayList certs; //of TMDCertContext
    }
}