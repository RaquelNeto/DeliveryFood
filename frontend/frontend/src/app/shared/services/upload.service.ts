import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';

@Injectable({
  providedIn: 'root'
})


export class UploadService {
  baseURL = 'https://localhost:44335/api/';

  constructor(private webReqService: WebRequestService) { }

  postUpload(file: File, name: string, id: string) {
    const fileToUplaod = <File>file;
    const formData = new FormData();
    formData.append('file', fileToUplaod, name);


    return this.webReqService.post(`Authenticate/upload?id=${id}`, formData);


  }
}
