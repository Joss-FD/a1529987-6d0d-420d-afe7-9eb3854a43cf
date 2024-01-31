import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from  '@angular/common/http';

@Component({
  selector: 'app-root',
  template: `
    <!--The content below is only a placeholder and can be replaced.-->
    <div style="text-align:center">
      <h1>
        Longest Incremental Sequence Finder
      </h1>
      <div class="content">
        <span> Enter a list of numbers seperated by a whitespace </span>
        <textarea placeholder="Enter numbers..." cols="30" rows="10" [value]="inputText" (input)="updateValue($event)"></textarea>
        <button (click)="getLongestSequence()">Find</button>
        <p *ngIf="isLoading">{{loadingText}}</p>
        <p class="error" *ngIf="showError">{{errorText}}</p>
        <p #output>
        {{inputSnapshot}}
        </p>
      </div>
    </div>
    
  `,
  styles: []
})
export class AppComponent {

  constructor(private http: HttpClient) {

  }

  @ViewChild('output', {static: true})
  output!: ElementRef;

  title = 'WebView';

  inputText: string = "";
  inputSnapshot: string = "";
  resultSequence: any = "";
  showError: boolean = false;
  errorText: string = "";
  isLoading: boolean = false;
  loadingText: string = "";


  updateValue(e: Event) {
    this.inputText = (e.target as HTMLTextAreaElement).value;
  }



  getLongestSequence() {
    //sanitize input
    this.inputText = this.inputText.replace(/  +/g, ' ').trimStart().trimEnd()
    if(!this.inputText || this.inputText.match(/[^ $\d]/) ) {
      this.errorText = "Invalid input. Please enter only numbers seperated by a whitespace";
      this.showError = true;
      return;
    }

    this.startLoad()
    this.http.post("https://localhost:7186/FindSequence",  this.inputText.toString(), {responseType: 'text'}).subscribe(res => { 
      this.inputSnapshot = this.inputText;
      this.resultSequence = res.toString();
      this.updateView();
      this.stopLoad()
    }, 
    err => { 
      console.log("err");
      
      this.stopLoad()
      this.showError = true;
      this.errorText = "Couldn't get response from API";
    }
    );
    
  }

  subroutine: any;
  startLoad() {
    this.showError = false;
    this.isLoading = true;
    this.subroutine = setInterval(() => {
      if(this.loadingText == "...") {
        this.loadingText = ""
      }
      else {
        this.loadingText += '.';
      }
    }, 300)  
   
  }

  stopLoad() {
    this.isLoading = false;
    this.loadingText = ""
    clearInterval(this.subroutine);
  }

  updateView() {
    this.output.nativeElement.innerHTML = this.inputSnapshot.replace(this.resultSequence, `<span id="target" class="highlight"> ${this.resultSequence}</span>`);
    this.scroll()
  }

  scroll() {
    let el: HTMLElement = document.getElementById("target")!;
    el.scrollIntoView({behavior: 'smooth', block: 'center', inline: 'center'});
  }

}
