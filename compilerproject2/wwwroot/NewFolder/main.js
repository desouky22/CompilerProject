/*
*this contain all keywords in project2# lanaguage
*/
var key_word=new Array(
    "Category",
    "Derive",
    "If",
    "Ilap",
    "Silap",
    "Clop",
    "Series",
    "Ilapf",
    "None",
    "terminatethis",
    "Rotatewhen",
    "Continuewhen",
    "Replywith",
    "Seop",
    "Check",
    "situationof",
    "Program",
    "End",
    "Using"
);
var tree=new Array();
function say_ok() {
    console.log("main js file included");
}
var tab_displacement=0;
say_ok();
function comment(selected_string){
    //console.log(selected_string.toString());
    selected_code=selected_string.toString();
    if(selected_code.indexOf("<*")==0){
        uncommented_code=selected_code.replace("<*","");
        uncommented_code=uncommented_code.replace("*>","");
        document.getElementById("Code").value=document.getElementById("Code").value.replace(selected_code,uncommented_code);
    }
    else if(document.getElementById("Code").value.indexOf(selected_code)!=-1){
        commented="<*"+selected_code+"*>";
        var newCode=document.getElementById("Code").value.replace(selected_code,commented);
        document.getElementById("Code").value=newCode;
    }
}
document.getElementById("comment_uncomments").onclick=function(){
    comment(document.getSelection());
};
document.getElementById("Code").oninput=function(){
    availableTags=[
        "Category",
        "Derive",
        "If(){\n}",
        "Else If({\n})",
        "Ilap",
        "Silap ",
        "Clop",
        "Series",
        "Ilapf",
        "Silapf",
        "None",
        "Logical",
        "terminatethis",
        "Rotatewhen(){\n}",
        "Continuewhen()",
        "Replywith",
        "Seop",
        "Check()",
        "situationof :",
        "Program\n",
        "End\n",
        "Using ();\n",

    ]
    $( "#Code" ).autocomplete({
	    source: availableTags
    });
    console.log("colored");
};
document.getElementById("formate").onclick=function(){
    formate(document.getElementById("Code").value,tab_displacement);
};
function build_char_record(Code,char,closed_char){
    var i=0;
    var line_no=0;
    var check_table=new Array();
    for(i=0;i<Code.length;i++){
        if(Code.charAt(i)==char||Code.charAt(i)==closed_char){
            record=new Array(Code.charAt(i),line_no+1);
            check_table.push(record);
        }
        if(Code.charAt(i)=="\n"){
            line_no=line_no+1;
        }
    }
    return check_table;
}
function char_is_unbalanced(check_table,char,closed_char){
    //count open char
    var i=0;
    var open_score=0;
    var closed_score=0;
    for(i=0;i<check_table.length;i++){
        if(check_table[i][0]==char){
            open_score=open_score+1;
        }
        else if(check_table[i][0]==closed_char){
            closed_score=closed_score+1;
        }
    }
    if(closed_score==open_score){
        return true;
    }
    return false;
}
function checkchar(Code,char,closed_char){
    check_table=build_char_record(Code,char,closed_char);
    if(char_is_unbalanced(check_table,char,closed_char)){
        return "no error\n";
    }else{
        if(char=="{"||char=="}"){
            if(check_table.length==0){
                return "{} are balanced"
            }
            return "EOF Error in line "+check_table[check_table.length-1][1].toString()+"\n";
        }
        else if(char=="("||char==")"){
            if(check_table.length==0){
                return "() are balanced"+"\n";
            }
            return "check the paranthese again"+"\n";
        }
    }
}
function checkErrors(){
    document.getElementById("Code_output").value="";
    Code=document.getElementById("Code").value;
    var current=document.getElementById("Code_output").value;
    var error_message=checkchar(Code,"{","}");
    current=error_message+current;
    error_message=checkchar(Code,"(",")");
    current=error_message+current;
    document.getElementById("Code_output").value=current;
}
setInterval(checkErrors, 1000);