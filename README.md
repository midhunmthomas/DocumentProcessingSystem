# DocumentProcessingSystem

A backend system for processing PDF documents with features like file upload, background processing, text extraction, and duplicate detection.

## Features

- **File Upload API**: Upload single or multiple PDF files with validation
- **Duplicate Detection**: Hash-based file deduplication
- **Status Tracking**: Real-time status updates for uploaded documents
- **Background Processing**: Asynchronous document processing using hosted services(Not accurate)
## Architecture

- **DocumentProcessing.API Layer**: ASP.NET Core Web API with controllers
- **DocumentProcessing.Service**: Business logic and domain entities
- **DocumentProcessing.Data**: Data access with Entity Framework Core
- **Layered Architecture**: Clean separation of concerns with dependency injection

## Technologies

- ASP.NET Core 8
- Entity Framework Core (SQserver)

## Setup Instructions

### Prerequisites

- .NET 7 SDK or higher
- Visual Studio 2022 or VS Code

### Installation

1. Clone the repository:
```bash
[git clone <repository-url>
cd DocumentProcessingSystem](https://github.com/midhunmthomas/DocumentProcessingSystem.git)
```

2. Restore NuGet packages:
```bash
dotnet restore
```

3. Build the solution:
```bash
dotnet build
```

4. Run the API:
```bash
cd src/DocumentProcessing.API
dotnet run
```

The API will be available at `[https://localhost:7092/]` (or the port shown in console).



## API Usage

### Upload File

```http
 -X 'POST' \
  'https://localhost:7092/api/Documents/upload' \
  -H 'accept: */*' \
  -H 'Content-Type: multipart/form-data' \
  -F 'files=@Passport .pdf;type=application/pdf'(https://localhost:7092/api/Documents/upload)

file: [PDF file]
```

**Response:**

'Files uploaded.
```



### Get All Documents

curl -X 'GET' \
  'https://localhost:7092/api/Documents' \
  -H 'accept: */*'
```

**Response:**
```json

 [
  {
    "id": null,
    "fileName": "S5 Grade Card.pdf",
    "filePath": "Uploads\\0c3013c4-e5f6-44c5-bd57-576ba5321de9.pdf",
    "fileSize": 579440,
    "fileHash": "wfRu0krkum/wSzXDgvXGtC7gdaFrdYcuL8Ald5ovOSI=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "BTech Certificate.pdf .pdf",
    "filePath": "Uploads\\9b2399d7-0d0a-44c9-9e0d-59620f2c3a9b.pdf",
    "fileSize": 378668,
    "fileHash": "TvQ5P82WIpJtchrbP5+DATnnUOeBy1VJGlkxubhjTN0=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "S1 Grade Card.pdf",
    "filePath": "Uploads\\bc815879-2f0e-44a5-afeb-2126cf5fe5dd.pdf",
    "fileSize": 132933,
    "fileHash": "UmmnOL5EVXEx+j254vAmWCZKJ+AGlAJ/wC/wfw0seE0=",
    "metadata": "{}",
    "status": "Completed",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "LOR-P.pdf",
    "filePath": "Uploads\\892bb147-d08a-47f9-90c3-72547c38f3a0.pdf",
    "fileSize": 473715,
    "fileHash": "kGTAZoegk+8m7r4+ARWAbi0tlqj4tq4/14CFDXcY/6c=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "S2 Grade Card.pdf",
    "filePath": "Uploads\\25f94443-cfa0-4f61-88fa-2da11371f82c.pdf",
    "fileSize": 133195,
    "fileHash": "yYcDOqAekRcx63k5b3loTO9Hs7unJrzCEtykyg+GLMQ=",
    "metadata": "{}",
    "status": "Completed",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "LOR Midhun M Thomas new.pdf",
    "filePath": "Uploads\\c43470af-16a3-4a4b-8077-f49db22e85b1.pdf",
    "fileSize": 273090,
    "fileHash": "SWH8yyVW1ZP6p1updCK3wYgwh92ZlSyDEx8H5QIL7Dg=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "S3 Grade Card.pdf",
    "filePath": "Uploads\\ac67437a-c257-48b6-bd43-62a3d7d3d543.pdf",
    "fileSize": 579100,
    "fileHash": "7kfMtBsEb1O/vMUXYJ00jnvpbfAKdo4eCNoK5wlI3II=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "resume_midhun__m_thomas.pdf",
    "filePath": "Uploads\\0f3784cf-22b3-4f31-8eae-e823c716b877.pdf",
    "fileSize": 74812,
    "fileHash": "wo36kVVuF8hcNBCR/VBFRmUzgIaohMu+vbUuZfEuFuY=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "S4 Grade Card.pdf",
    "filePath": "Uploads\\aa83ff39-cf1e-4233-ad9d-0947ffd89da6.pdf",
    "fileSize": 579297,
    "fileHash": "UbuQDptrSDKaO5yp6OmtwX/LncbtW8nwhIdZLTHVLIk=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "resume_midhun__m_thomas_Data.pdf",
    "filePath": "Uploads\\7c29b0da-6e24-4156-a1c9-b4e3d0b100cf.pdf",
    "fileSize": 74920,
    "fileHash": "QQbt2Q7RbW1eiqOibRDcJgs8Q9uoxQulHxsGuVJ1Or4=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "Passport .pdf",
    "filePath": "Uploads\\9465d475-4c6c-49cf-a2f4-7253db7a2d21.pdf",
    "fileSize": 422367,
    "fileHash": "g7IqpjeRf2I/Yl6ZeYCTxAD/3AHCfCKD9r6zHC/zAEM=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "Provisional Certificate.pdf",
    "filePath": "Uploads\\9d00e4d1-9770-498b-bc71-b292553106bf.pdf",
    "fileSize": 1617105,
    "fileHash": "kl1nSQhQi48dpW2ubfZohX78LA5bpSAJccf3R/wa6S8=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "S7 Grade Card.pdf",
    "filePath": "Uploads\\313b0c64-cf56-4352-b2d8-180eaaf72ca8.pdf",
    "fileSize": 579290,
    "fileHash": "LenWsoHEUTQGh9kErJyxvVEPH4RtDRjpZUeSx8s01Co=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "S8 Grade Card.pdf",
    "filePath": "Uploads\\3f511580-dec0-4aa6-8c33-ae989e58e017.pdf",
    "fileSize": 208318,
    "fileHash": "aNX3IGBf69b+5bb1agXeh3w8ckquTyUepL5DOTwLXpg=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  },
  {
    "id": null,
    "fileName": "Consolidated grade card.pdf",
    "filePath": "Uploads\\9a0b411e-eecf-4045-8a0b-2cbbaa312c8d.pdf",
    "fileSize": 676350,
    "fileHash": "rs4Xbq93rRvTi0p2AOhxe85EjWc9pnZCKXv1htQLmJY=",
    "metadata": "{}",
    "status": "Uploaded",
    "uploadedAt": null
  }
]
```





## Document Processing Flow

1. **Upload**: File is validated (PDF, <10MB) and saved
2. **Hash Check**: System checks for duplicates using SHA256 hash
3. **Queue**: Non-duplicate files are queued for processing


## File Validation

- **File Type**: Only PDF files (.pdf extension)
- **File Size**: Maximum 10MB per file

