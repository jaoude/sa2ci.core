${
    // Enable extension methods by adding using Typewriter.Extensions.*
    using Typewriter.Extensions.WebApi;

    // Uncomment the constructor to change template settings.
    Template(Settings settings) 
    {
        settings.IncludeProject("Sa2ci.Core.Bll");
        settings.IncludeProject("Sa2ci.Core.Common");
    }

    bool ClassShouldBeExported(Class c) {  
        if (ExportToTypeScriptFilter(c)) { 
            return true;
        } 
        foreach (var nc in c.NestedClasses){  
            if (ClassShouldBeExported(nc)){
                return true;
            }
        }
        foreach (var ne in c.NestedEnums){
            if (ExportToTypeScriptFilter(ne)){
                return true;
            }
        }
        return false;
    } 

    bool ExportToTypeScriptFilter(Class c){
        bool select = false;
        foreach (var attr in c.Attributes){
            if (attr.Name == "ExportToTypescript"){
                select = true;
                break;
            }
        }
        return select;
    }

    bool ExportToTypeScriptFilter(Enum e){
        bool select = false;
        foreach (var attr in e.Attributes){
            if (attr.Name == "ExportToTypescript"){
                select = true;
                break;
            }
        }
        return select;
    } 

    string CustomProperty(Property p){
        if (p.Type.IsNullable || p.Type.IsEnumerable){
            return $"{p.Name}?: {p.Type};"; 
        }
        return $"{p.Name}: {p.Type};"; 
    }

    string GenerateImports(Class c){
        var imports="";
        foreach(var prop in c.Properties){
            if(prop.Type.IsEnumerable && prop.Type.IsGeneric){
                var genericType = prop.Type.TypeArguments.First();
                if(!genericType.FullName.Contains("System.")){
                    if(genericType.IsEnum)
                        imports += $"import {{ {genericType.Name} }} from './Constants'; \r\n";
                    else
                        imports += $"import {{ {genericType.Name} }} from './{genericType.Name}'; \r\n";
                }
            }
            if(!prop.Type.FullName.Contains("System.")){   
                if(prop.Type.IsEnum)
                    imports += $"import {{ {prop.Type.Name} }} from './Constants'; \r\n";
                else
                    imports += $"import {{ {prop.Type.Name} }} from './{prop.Type.Name}'; \r\n";
            }
        }
        return imports;     
    }
}$Classes(c => ClassShouldBeExported(c))[$GenerateImports

export interface $Name$TypeParameters { $Properties[
        $CustomProperty]
}]
$Enums(e => ExportToTypeScriptFilter(e))[export enum $Name {
        $Values[
        $Name = $Value][,]
}
]