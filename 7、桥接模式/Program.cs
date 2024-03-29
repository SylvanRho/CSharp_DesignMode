﻿using System;

namespace _7_桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            PlatformImplementor SqlServer2000UnixImp = new SqlServer2000UnixImplementor();
            Database database = new SqlServer2000(SqlServer2000UnixImp);
            database.Create();

            Console.ReadKey();
        }

        /// <summary>
        /// 该抽象类就是抽象接口的定义，该类型就相当于是Abstraction类型
        /// </summary>
        public abstract class Database
        {
            //通过组合方式引用平台接口，此处就是桥梁，该类型相当于Implementor类型
            protected PlatformImplementor _implementor;

            //通过构造器注入，初始化平台实现
            public Database(PlatformImplementor implementor)
            {
                _implementor = implementor;
            }

            //创建数据库--该操作相当于Abstraction类型的Operation方法
            public abstract void Create();
        }

        /// <summary>
        /// 该抽象类就是实现接口的定义，该类型就相当于是Implementor类型
        /// </summary>
        public abstract class PlatformImplementor
        {
            //该方法就相当于Implementor类型的OperationImpl方法
            public abstract void Process();
        }

        /// <summary>
        /// SqlServer2005版本的数据库，相当于RefinedAbstraction类型
        /// </summary>
        public class SqlServer2005 : Database
        {
            //构造函数初始化
            public SqlServer2005(PlatformImplementor implementor) : base(implementor) { }

            public override void Create()
            {
                this._implementor.Process();
            }
        }

        /// <summary>
        /// SqlServer2000版本的数据库，相当于RefinedAbstraction类型
        /// </summary>
        public class SqlServer2000 : Database
        {
            //构造函数初始化
            public SqlServer2000(PlatformImplementor implementor) : base(implementor) { }

            public override void Create()
            {
                _implementor.Process();
            }
        }

        /// <summary>
        /// SqlServer2000版本的数据库针对Unix操作系统的具体实现，相当于ConcreteImplementorB类型
        /// </summary>
        public class SqlServer2000UnixImplementor : PlatformImplementor
        {
            public override void Process()
            {
                Console.WriteLine("SqlServer2000针对Unix的具体实现");
            }
        }

        /// <summary>
        /// SqlServer2005版本的数据库针对Unix操作系统的具体实现，相当于ConcreteImplementorB类型
        /// </summary>
        public sealed class SqlServer2005UnixImplementor : PlatformImplementor
        {
            public override void Process()
            {
                Console.WriteLine("SqlServer2005针对Unix的具体实现");
            }
        }
    }
}
