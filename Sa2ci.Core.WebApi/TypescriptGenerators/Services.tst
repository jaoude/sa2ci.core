${
    // Enable extension methods by adding using Typewriter.Extensions.*
    using Typewriter.Extensions.WebApi;

    // Uncomment the constructor to change template settings.
    Template(Settings settings)
    {
        settings.OutputFilenameFactory = File =>
        {
            return $"{File.Name.Replace("Controller.cs", "Service.ts")}";
        };
    }
    
    string ReturnType(Method m) {
    var returnType = m.Type.TypeArguments.FirstOrDefault();  
    if(m.Type.IsEnumerable || returnType==null)
        return m.Type.Name == "void" || m.Type.Name == "IActionResult" ? "any": m.Type.Name;
    else  
        return returnType.Name;
    } 

    string ServiceName(Class c) => c.Name.Replace("Controller", "Service");

    string ToLowerCase(string s){
        return Char.ToLowerInvariant(s[0]) + s.Substring(1);
    }

    string GenerateImports(Class c){
        var imports="";
        foreach(var m in c.Methods){
            foreach(var param in m.Parameters){
                if(!param.Type.FullName.Contains("System."))
                {
                    var import = $"import {{ {CleanName(param.Type)} }} from '@/models/generated/{CleanName(param.Type)}';\r\n";
                    if(!imports.Contains(import))
                    imports+=import;
                }
            }
            Type returnType=null;
            if(m.Type.IsGeneric){
                returnType = m.Type.TypeArguments.FirstOrDefault(t=>t.FullName.Contains("Sa2ci.Core"));
                if(returnType!=null)
                    returnType = returnType.IsGeneric ? returnType.TypeArguments.FirstOrDefault(t => t.FullName.Contains("Sa2ci.Core")):returnType;
            }
            else{
                returnType = m.Type;
            }   

            if(!(returnType==null) || returnType.Name=="void"){
                if(!returnType.FullName.Contains("System.")){
                    var import = $"import {{ {returnType.Name} }} from '@/models/generated/{returnType.Name}';\r\n";
                    if(!imports.Contains(import))
                    imports+=import;
                }
            }
        }
        return imports;
    }

    string CleanName(Type type){
        if(!type.IsGeneric)
            return type.Name;
        return type.Name.Remove(type.Name.IndexOf("<")); 
    }

    string CleanNameParameter(Type type){ 
        if(!type.IsGeneric)
            return type.Name;
        return type.Name.Remove(type.Name.IndexOf("<"))+"<any>";
    }

    string RequestPayLoad(Method m){
        if(m.HttpMethod()=="post")
            return $"data : {m.RequestData()}";
        else
            return $"params : {m.RequestData()}";
    }
} 
$Classes(:ControllerBase)[$GenerateImports] 
import api from '@/infrastructure/api'
$Classes(:ControllerBase)[
export class $ServiceName {
    $Methods[

    public $name ($Parameters[$name?: $Type[$CleanNameParameter]][, ]){
        return api.request<$ReturnType>({
            url:`$Url`,
            method: "$HttpMethod",
            $RequestPayLoad
        });
    }]
}

export const $ServiceName[$ToLowerCase]= new $ServiceName();
