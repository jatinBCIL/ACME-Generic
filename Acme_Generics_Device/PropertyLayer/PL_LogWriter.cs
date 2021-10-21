using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// Purpose : Class is created to declare log writer property fields.
/// Created On : 13 August, 2012.
/// Created By : Chandrakant Shindkar.
/// Modified On :
/// Modified By :
/// Comment :
/// </summary>
public class PL_LogWriter
{
    private string MODULENAME;
    private string FUNCTIONNAME;
    private string ERRORTYPE;
    private string ERRORDESCRIPTION;
    private string CRUSER;
    private string _PROGRAM;
    private string _PLANTS;

    public string strModuleName
    {
        get
        {
            return MODULENAME;
        }
        set
        {
            MODULENAME = value;
        }
    }

    public string strFunctionName
    {
        get
        {
            return FUNCTIONNAME;
        }
        set
        {
            FUNCTIONNAME = value;
        }
    }

    public string strErrorType
    {
        get
        {
            return ERRORTYPE;
        }
        set
        {
            ERRORTYPE = value;
        }
    }

    public string strDescription
    {
        get
        {
            return ERRORDESCRIPTION;
        }
        set
        {
            ERRORDESCRIPTION = value;
        }
    }

    public string strUsername
    {
        get
        {
            return CRUSER;
        }
        set
        {
            CRUSER = value;
        }
    }

    public string strProgram
    {
        get
        {
            return _PROGRAM;
        }
        set
        {
            _PROGRAM = value;
        }
    }
    public string strPlants
    {
        get
        {
            return _PLANTS;
        }
        set
        {
            _PLANTS = value;
        }
    }
}
