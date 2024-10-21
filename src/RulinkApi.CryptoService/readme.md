## API client для работы с сервисом электронной подписи ##

Swagger API: [https://rulink.io/api/v2/crypto/swagger](https://rulink.io/api/v2/crypto/swagger/index.html)

Примеры использования в проекте test/RulinkApi.Tests


Реализация методов для работы с сервисом электронной подписи
1. Проверка подписи документа
2. Получение информации о подписантах из sig-файла
3. Объединение нескольких sig-файлов в один
4. Удаление подписанта из sig-файла


### Примеры использования ###
1. Проверка электронной подписи
```csharp
        _cryptoServiceClient = new CryptoServiceClient("https://rulink.io/api/v2/crypto", "your-api-key");
        var VerificationRequest = new SignatureVerificationRequest
        {
            Data = File.ReadAllBytes("data\\contract.pdf"),
            Signature= File.ReadAllBytes("data\\contract.pdf.sig"),
        };
        var result = _cryptoServiceClient.VerifySignature(VerificationRequest, null);
```
Результат
```json
{
	"verificationResult": {
		"isFileVerificationSuccess": true,
		"signatures": [
			{
				"companyName": "ООО \"ОБЛАКОТЕХ\"",
				"subject": "Разработчиков Иван Иванович",
				"subjectEmail": "ivan@rus-contoso.ru",
				"city": "Москва",
				"serialNumber": "01df59e80054ac71bf455b35e2907bfc88",
				"issueDate": "2020-10-14T13:55:59Z",
				"validBefore": "2021-10-14T14:05:59Z",
				"signedDate": "2021-05-14T13:42:23Z",
				"position": "Старший менеджер продукта",
				"algorithm": "ГОСТ2012 256Бит (ГОСТ Р 34.10-2012 256 бит)",
				"isValidNow": false,
				"isFileMatch": true,
				"revocatedDetails": {
					"isRevocated": false,
					"revocatedDate": null,
					"revocatedDescription": null,
					"crlUrl": "http://ca.roseltorg.ru/cdp/a4fc5f8b3abb1e71b5c8c0eb779b3926a297853c.crl"
				},
				"caDetails": {
					"title": "АО \"ЕЭТП\"",
					"url": "http://www.roseltorg.ru/ecp",
					"isAccredited": true,
					"isTrusted": true,
					"status": "Действует",
					"lastStatusUpdate": "2012-08-06T20:00:00",
					"ogrnCode": "1097746299353",
					"email": "uc@roseltorg.ru"
				}
			}
		],
		"dataFileLenght": 53904,
		"signatureFileLenght": 6856
	},
	"isSuccess": true,
	"message": "",
	"traceId": "4b3b56cd"
}
```

2. Получение информации о подписантах из sig-файла
```csharp
        _cryptoServiceClient = new CryptoServiceClient("https://rulink.io/api/v2/crypto", "your-api-key");
        var VerificationRequest = new SignatureVerificationRequest
        {
            Data = null,
            Signature= File.ReadAllBytes("data\\contract.pdf.sig"),
        };
        var result = _cryptoServiceClient.VerifySignature(VerificationRequest, null);
```
Результат
```json
{
	"verificationResult": {
		"isFileVerificationSuccess": false,
		"signatures": [
			{
				"companyName": "ООО \"ОБЛАКОТЕХ\"",
				"subject": "Разработчиков Иван Иванович",
				"subjectEmail": "ivan@rus-contoso.ru",
				"city": "Москва",
				"serialNumber": "01df59e80054ac71bf455b35e2907bfc88",
				"issueDate": "2020-10-14T13:55:59Z",
				"validBefore": "2021-10-14T14:05:59Z",
				"signedDate": "2021-05-14T13:42:23Z",
				"position": "Старший менеджер продукта",
				"algorithm": "ГОСТ2012 256Бит (ГОСТ Р 34.10-2012 256 бит)",
				"isValidNow": false,
				"isFileMatch": true,
				"revocatedDetails": {
					"isRevocated": false,
					"revocatedDate": null,
					"revocatedDescription": null,
					"crlUrl": "http://ca.roseltorg.ru/cdp/a4fc5f8b3abb1e71b5c8c0eb779b3926a297853c.crl"
				},
				"caDetails": {
					"title": "АО \"ЕЭТП\"",
					"url": "http://www.roseltorg.ru/ecp",
					"isAccredited": true,
					"isTrusted": true,
					"status": "Действует",
					"lastStatusUpdate": "2012-08-06T20:00:00",
					"ogrnCode": "1097746299353",
					"email": "uc@roseltorg.ru"
				}
			}
		]
	},
	"isSuccess": true,
	"message": "",
	"traceId": "4b3b56cd"
}
```


3. Объединение нескольких sig-файлов в один
```csharp
        _cryptoServiceClient = new CryptoServiceClient("https://rulink.io/api/v2/crypto", "your-api-key");
        var mergeTwoSigFilesRequest = new SignatureMergeRequest()
        {
            Signature= File.ReadAllBytes("data\\signatureFile1.sig"),
            SecondSignature = File.ReadAllBytes("data\\signatureFile2.sig")
        };
        var result = _cryptoServiceClient.MergeSignatures(mergeTwoSigFilesRequest, "your-trace-id-if-need");
```
Результат
```json
{
	"NewSignatures": "MIA...AAAA=",
	"isSuccess": true,
	"message": "",
	"traceId": "d2b28389"
}
```


4. Удаление подписанта из sig-файла
```csharp
        _cryptoServiceClient = new CryptoServiceClient("https://rulink.io/api/v2/crypto", "your-api-key");
        var removeSignerRequest = new SignatureRemoveRequest()
        {
            Signature= File.ReadAllBytes("data\\signatureFile1.sig"),
            SerialNumberArray = ["01df59e80054ac71bf455b35e2907bfc88"]
        };
        var result = _cryptoServiceClient.RemoveSigner(removeSignerRequest, "your-trace-id-if-need");
```
Результат
```json
{
	"NewSignatures": "MIA...AAAA=",
	"isSuccess": true,
	"message": "",
	"traceId": "d2b28388"
}
```