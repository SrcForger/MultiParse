using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPDefault
    {
        public static void RegisterDataTypes(List<MPDataType> datatypeList, DataTypes types)
        {
            if ((types & DataTypes.Int32) == DataTypes.Int32)
                datatypeList.Add(new MPInt32());
            if ((types & DataTypes.UInt32) == DataTypes.UInt32)
                datatypeList.Add(new MPUInt32());
            if ((types & DataTypes.Int64) == DataTypes.Int64)
                datatypeList.Add(new MPInt64());
            if ((types & DataTypes.UInt64) == DataTypes.UInt64)
                datatypeList.Add(new MPUInt64());
            if ((types & DataTypes.SByte) == DataTypes.SByte)
                datatypeList.Add(new MPSByte());
            if ((types & DataTypes.Boolean) == DataTypes.Boolean)
                datatypeList.Add(new MPBoolean());
            if ((types & DataTypes.Decimal) == DataTypes.Decimal)
                datatypeList.Add(new MPDecimal());
            if ((types & DataTypes.Double) == DataTypes.Double)
                datatypeList.Add(new MPDouble());
            if ((types & DataTypes.Single) == DataTypes.Single)
                datatypeList.Add(new MPSingle());
            if ((types & DataTypes.Char) == DataTypes.Char)
                datatypeList.Add(new MPChar());
            if ((types & DataTypes.String) == DataTypes.String)
                datatypeList.Add(new MPString());
            if ((types & DataTypes.Int16) == DataTypes.Int16)
                datatypeList.Add(new MPInt16());
            if ((types & DataTypes.UInt16) == DataTypes.UInt16)
                datatypeList.Add(new MPUInt16());
            if ((types & DataTypes.Byte) == DataTypes.Byte)
                datatypeList.Add(new MPByte());
            if ((types & DataTypes.Variable) != DataTypes.Variable)
                return;
            datatypeList.Add(new MPVariable());
        }

        public static void RegisterTypeCasts(List<MPOperator> operatorList, DataTypes casts)
        {
            if ((casts & DataTypes.Boolean) == DataTypes.Boolean)
                operatorList.Add(new MPBooleanCast());
            if ((casts & DataTypes.Byte) == DataTypes.Byte)
                operatorList.Add(new MPByteCast());
            if ((casts & DataTypes.Char) == DataTypes.Char)
                operatorList.Add(new MPCharCast());
            if ((casts & DataTypes.Decimal) == DataTypes.Decimal)
                operatorList.Add(new MPDecimalCast());
            if ((casts & DataTypes.Double) == DataTypes.Double)
                operatorList.Add(new MPDoubleCast());
            if ((casts & DataTypes.Int16) == DataTypes.Int16)
                operatorList.Add(new MPInt16Cast());
            if ((casts & DataTypes.Int32) == DataTypes.Int32)
                operatorList.Add(new MPInt32Cast());
            if ((casts & DataTypes.Int64) == DataTypes.Int64)
                operatorList.Add(new MPInt64Cast());
            if ((casts & DataTypes.SByte) == DataTypes.SByte)
                operatorList.Add(new MPSByteCast());
            if ((casts & DataTypes.Single) == DataTypes.Single)
                operatorList.Add(new MPSingleCast());
            if ((casts & DataTypes.String) == DataTypes.String)
                operatorList.Add(new MPStringCast());
            if ((casts & DataTypes.UInt16) == DataTypes.UInt16)
                operatorList.Add(new MPUInt16Cast());
            if ((casts & DataTypes.UInt32) == DataTypes.UInt32)
                operatorList.Add(new MPUInt32Cast());
            if ((casts & DataTypes.UInt64) != DataTypes.UInt64)
                return;
            operatorList.Add(new MPUInt64Cast());
        }

        public static void RegisterOperators(
          List<MPOperator> operatorList,
          Operators operators)
        {
            if ((operators & Operators.LeftShift) == Operators.LeftShift)
                operatorList.Add(new MPLeftShift());
            if ((operators & Operators.RightShift) == Operators.RightShift)
                operatorList.Add(new MPRightShift());
            if ((operators & Operators.RelationalSmallerEqual) == Operators.RelationalSmallerEqual)
                operatorList.Add(new MPRelationalSmallerEqual());
            if ((operators & Operators.RelationalLargerEqual) == Operators.RelationalLargerEqual)
                operatorList.Add(new MPRelationalLargerEqual());
            if ((operators & Operators.RelationalSmaller) == Operators.RelationalSmaller)
                operatorList.Add(new MPRelationalSmaller());
            if ((operators & Operators.RelationalLarger) == Operators.RelationalLarger)
                operatorList.Add(new MPRelationalLarger());
            if ((operators & Operators.ConditionalAnd) == Operators.ConditionalAnd)
                operatorList.Add(new MPConditionalAnd());
            if ((operators & Operators.ConditionalOr) == Operators.ConditionalOr)
                operatorList.Add(new MPConditionalOr());
            if ((operators & Operators.LogicalAnd) == Operators.LogicalAnd)
                operatorList.Add(new MPLogicalAnd());
            if ((operators & Operators.LogicalOr) == Operators.LogicalOr)
                operatorList.Add(new MPLogicalOr());
            if ((operators & Operators.LogicalXOr) == Operators.LogicalXOr)
                operatorList.Add(new MPLogicalXOr());
            if ((operators & Operators.Addition) == Operators.Addition)
                operatorList.Add(new MPAddition());
            if ((operators & Operators.Subtraction) == Operators.Subtraction)
                operatorList.Add(new MPSubtraction());
            if ((operators & Operators.Multiplication) == Operators.Multiplication)
                operatorList.Add(new MPMultiplication());
            if ((operators & Operators.Division) == Operators.Division)
                operatorList.Add(new MPDivision());
            if ((operators & Operators.Equality) == Operators.Equality)
                operatorList.Add(new MPEquality());
            if ((operators & Operators.Inequality) == Operators.Inequality)
                operatorList.Add(new MPInequality());
            if ((operators & Operators.Modulo) == Operators.Modulo)
                operatorList.Add(new MPModulo());
            if ((operators & Operators.Positive) == Operators.Positive)
                operatorList.Add(new MPPositive());
            if ((operators & Operators.Negative) == Operators.Negative)
                operatorList.Add(new MPNegative());
            if ((operators & Operators.Not) == Operators.Not)
                operatorList.Add(new MPNot());
            if ((operators & Operators.Complement) == Operators.Complement)
                operatorList.Add(new MPComplement());
            if ((operators & Operators.Assignment) != Operators.Assignment)
                return;
            operatorList.Add(new MPAssignment());
        }

        public static void RegisterFunctions(
          List<MPBrackets> bracketList,
          Functions functions)
        {
            if ((functions & Functions.RoundBrackets) == Functions.RoundBrackets)
                bracketList.Add(new MPRoundBrackets());
            if ((functions & Functions.Abs) == Functions.Abs)
                bracketList.Add(new MPAbs());
            if ((functions & Functions.Acos) == Functions.Acos)
                bracketList.Add(new MPAcos());
            if ((functions & Functions.Asin) == Functions.Asin)
                bracketList.Add(new MPAsin());
            if ((functions & Functions.Atan) == Functions.Atan)
                bracketList.Add(new MPAtan());
            if ((functions & Functions.Atan2) == Functions.Atan2)
                bracketList.Add(new MPAtan2());
            if ((functions & Functions.Ceiling) == Functions.Ceiling)
                bracketList.Add(new MPCeiling());
            if ((functions & Functions.Cos) == Functions.Cos)
                bracketList.Add(new MPCos());
            if ((functions & Functions.Cosh) == Functions.Cosh)
                bracketList.Add(new MPCosh());
            if ((functions & Functions.Exp) == Functions.Exp)
                bracketList.Add(new MPExp());
            if ((functions & Functions.Floor) == Functions.Floor)
                bracketList.Add(new MPFloor());
            if ((functions & Functions.Log) == Functions.Log)
                bracketList.Add(new MPLog());
            if ((functions & Functions.Log10) == Functions.Log10)
                bracketList.Add(new MPLog10());
            if ((functions & Functions.Max) == Functions.Max)
                bracketList.Add(new MPMax());
            if ((functions & Functions.Min) == Functions.Min)
                bracketList.Add(new MPMin());
            if ((functions & Functions.Pow) == Functions.Pow)
                bracketList.Add(new MPPow());
            if ((functions & Functions.Round) == Functions.Round)
                bracketList.Add(new MPRound());
            if ((functions & Functions.Sign) == Functions.Sign)
                bracketList.Add(new MPSign());
            if ((functions & Functions.Sin) == Functions.Sin)
                bracketList.Add(new MPSin());
            if ((functions & Functions.Sqrt) == Functions.Sqrt)
                bracketList.Add(new MPSqrt());
            if ((functions & Functions.Tan) == Functions.Tan)
                bracketList.Add(new MPTan());
            if ((functions & Functions.Tanh) == Functions.Tanh)
                bracketList.Add(new MPTanh());
            if ((functions & Functions.Truncate) != Functions.Truncate)
                return;
            bracketList.Add(new MPTruncate());
        }

        public enum DataTypes : uint
        {
            None = 0,
            Boolean = 1,
            Byte = 2,
            Char = 4,
            Decimal = 8,
            Double = 16, // 0x00000010
            Int16 = 32, // 0x00000020
            Short = 32, // 0x00000020
            Int = 64, // 0x00000040
            Int32 = 64, // 0x00000040
            Int64 = 128, // 0x00000080
            Long = 128, // 0x00000080
            SByte = 256, // 0x00000100
            Float = 512, // 0x00000200
            Single = 512, // 0x00000200
            String = 1024, // 0x00000400
            UInt16 = 2048, // 0x00000800
            UShort = 2048, // 0x00000800
            UInt = 4096, // 0x00001000
            UInt32 = 4096, // 0x00001000
            UInt64 = 8192, // 0x00002000
            ULong = 8192, // 0x00002000
            Variable = 16384, // 0x00004000
            All = 4294967295, // 0xFFFFFFFF
        }

        public enum Operators : uint
        {
            None = 0,
            Addition = 1,
            Complement = 2,
            ConditionalAnd = 4,
            ConditionalOr = 8,
            Division = 16, // 0x00000010
            Equality = 32, // 0x00000020
            Inequality = 64, // 0x00000040
            LeftShift = 128, // 0x00000080
            LogicalAnd = 256, // 0x00000100
            LogicalOr = 512, // 0x00000200
            LogicalXOr = 1024, // 0x00000400
            Modulo = 4096, // 0x00001000
            Multiplication = 8192, // 0x00002000
            Negative = 16384, // 0x00004000
            Not = 32768, // 0x00008000
            Positive = 65536, // 0x00010000
            RelationalLarger = 131072, // 0x00020000
            RelationalLargerEqual = 262144, // 0x00040000
            RelationalSmaller = 524288, // 0x00080000
            RelationalSmallerEqual = 1048576, // 0x00100000
            RightShift = 2097152, // 0x00200000
            Subtraction = 4194304, // 0x00400000
            Assignment = 8388608, // 0x00800000
            All = 4294967295, // 0xFFFFFFFF
        }

        public enum Functions : uint
        {
            None = 0,
            Abs = 1,
            Acos = 2,
            Asin = 4,
            Atan = 8,
            Atan2 = 16, // 0x00000010
            Ceiling = 32, // 0x00000020
            Cos = 64, // 0x00000040
            Cosh = 128, // 0x00000080
            Exp = 256, // 0x00000100
            Floor = 512, // 0x00000200
            Log = 1024, // 0x00000400
            Log10 = 2048, // 0x00000800
            Max = 4096, // 0x00001000
            Min = 8192, // 0x00002000
            Pow = 16384, // 0x00004000
            Round = 32768, // 0x00008000
            Sign = 65536, // 0x00010000
            Sin = 131072, // 0x00020000
            Sqrt = 262144, // 0x00040000
            Tan = 524288, // 0x00080000
            Tanh = 1048576, // 0x00100000
            Truncate = 2097152, // 0x00200000
            RoundBrackets = 4194304, // 0x00400000
            All = 4294967295, // 0xFFFFFFFF
        }
    }
}