using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;

/// <summary>
/// Summary description for CustomRequestValidator
/// </summary>
public class CustomRequestValidator : RequestValidator
{
    protected override bool IsValidRequestString(
        HttpContext context, string value,
        RequestValidationSource requestValidationSource,
        string collectionKey,
        out int validationFailureIndex)
    {
        if (requestValidationSource == RequestValidationSource.Form)
        {
            int errorIndex = value.IndexOf("<script>");
            if (errorIndex != -1)
            {
                validationFailureIndex = errorIndex;
                return false;
            }
            else
            {
                validationFailureIndex = 0;
                return true;
            }
        }
        else
        {
            return base.IsValidRequestString(context, value,
                requestValidationSource, collectionKey, out validationFailureIndex);
        }
    }
}